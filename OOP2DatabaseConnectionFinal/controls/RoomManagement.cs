using OOP2DatabaseConnectionFinal.Classes;
using OOP2DatabaseConnectionFinal.DataSet2TableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: Add an option for a bed with no patient.

namespace OOP2DatabaseConnectionFinal
{
    public partial class RoomManagement : BasicControl
    {
        List<Ward> wardsToBind;
        List<Room> roomsFromData;
        List<Room> roomsToBind;
        bool isLoaded;
        public RoomManagement() : base()
        {
            wardsToBind = new List<Ward>();
            roomsFromData = new List<Room>();
            roomsToBind = new List<Room>();
            isLoaded = false;
            InitializeComponent();
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {
            patientTableAdapter.Fill(dataSet2.patient);

            //fill the dataset defined by the designer and fill the rows
            roomTableAdapter.Fill(dataSet2.room);

            foreach (DataRow row in dataSet2.room.Rows)
            {
                int roomNumber = Convert.ToInt32(row[0]);
                char wardLetter = Convert.ToChar(row[1]);
                string roomName = Convert.ToString(row[2]);
                char roomType = Convert.ToChar(row[3]);

                //only display patient rooms, because medical rooms won't have any beds to manage!
                if (roomType == 'P')
                {
                    Room room = new PatientRoom(roomNumber, wardLetter, roomName);
                    roomsFromData.Add(room);
                }
            }

            wardTableAdapter.Fill(dataSet2.ward);

            foreach (DataRow row in dataSet2.ward.Rows)
            {
                char wardLetter = Convert.ToChar(row[0]);
                string wardName = Convert.ToString(row[1]);

                Ward ward = new Ward(wardLetter, wardName);
                wardsToBind.Add(ward);
            }

            comboBox1.DataSource = wardsToBind;

            comboBox1.DisplayMember = "WardLetter";
            comboBox1.ValueMember = "WardLetter";

            roomsToBind.Clear();
            foreach (Room room in roomsFromData)
            {
                if (Convert.ToString(room.WardLetter) == comboBox1.Text)
                    roomsToBind.Add(room);
            }

            comboBox2.DataSource = null;
            comboBox2.DataSource = roomsToBind;

            //display value represents our composite PK for the room.
            comboBox2.DisplayMember = "DisplayValue";
            comboBox2.ValueMember = "RoomNumber";

            isLoaded = true;

            fillDataGrid();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;


            roomsToBind.Clear();
            foreach (Room room in roomsFromData) {
                if (Convert.ToString(room.WardLetter) == comboBox1.Text)
                    roomsToBind.Add(room);
            }

            comboBox2.DataSource = null;
            comboBox2.DataSource = roomsToBind;

            //display value represents our composite PK for the room.
            comboBox2.DisplayMember = "DisplayValue";
            comboBox2.ValueMember = "RoomNumber";

            fillDataGrid();
        }


        private void fillDataGrid()
        {
            if (comboBox1.Text != "" && comboBox2.SelectedValue != null)
            {
                Int32 roomNumber = (Int32)comboBox2.SelectedValue;
                bedTableAdapter.BedsByRoom(dataSet2.bed, (int)roomNumber, comboBox1.Text);
            }

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;
            fillDataGrid();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //the current cell will start with the last cell plus one.
            if (e.Row.Index > 0)
            {
                int previousValue = Convert.ToInt32(dataGridView1.Rows[e.Row.Index - 1].Cells[0].Value);

                dataGridView1.Rows[e.Row.Index].Cells[0].Value = previousValue + 1;
            }
            else
            {
                dataGridView1.Rows[e.Row.Index].Cells[0].Value = 1;
            }

            e.Row.Cells[1].Value = comboBox2.SelectedValue;
            e.Row.Cells[2].Value = comboBox1.Text;
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
                return;

            var row = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (row != null && row.Row.RowState == DataRowState.Added)
            {
                bedTableAdapter.Insert(row.Row.Field<int>("bed_number"), row.Row.Field<int>("patient_number"), row.Row.Field<int>("room_number"), row.Row.Field<string>("ward_letter"));
            }
        }
    }
}
