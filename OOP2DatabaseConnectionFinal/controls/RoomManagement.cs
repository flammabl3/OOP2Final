using OOP2DatabaseConnectionFinal.Classes;
using OOP2DatabaseConnectionFinal.DataSet2TableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        List<Patient> patientsToBind;
        List<int> existingPatientNumbers;
        bool isLoaded;
        public RoomManagement() : base()
        {
            wardsToBind = new List<Ward>();
            roomsFromData = new List<Room>();
            roomsToBind = new List<Room>();
            patientsToBind = new List<Patient>();
            existingPatientNumbers = new List<int>();
            isLoaded = false;
            InitializeComponent();
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {

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

            UpdatePatientNumberOptions();

            //make a note of what patient numbers are present
            updateExistingPatients();

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


        //Use a custom query to find only the beds which match the selected room and ward.
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
            label3.Visible = false;

            if (dataGridView1.Rows[e.RowIndex].IsNewRow || dataGridView1.Rows[e.RowIndex].Cells[3].Value == DBNull.Value)
                return;

            var row = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (existingPatientNumbers.Contains(row.Row.Field<int>("patient_number")) && 
                (row.Row.RowState == DataRowState.Added || row.Row.RowState == DataRowState.Modified))
            {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = DBNull.Value;
                label3.Visible = true;
                return;
            }

            if (row != null)
            {
                if (row.Row.RowState == DataRowState.Added)
                {
                    if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].EditedFormattedValue) == "No Patient")
                        bedTableAdapter.Insert(row.Row.Field<int>("bed_number"), null, row.Row.Field<int>("room_number"), row.Row.Field<string>("ward_letter"));
                    else
                        bedTableAdapter.Insert(row.Row.Field<int>("bed_number"), row.Row.Field<int>("patient_number"), row.Row.Field<int>("room_number"), row.Row.Field<string>("ward_letter"));
                } else if (row.Row.RowState == DataRowState.Modified)
                {
                    if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].EditedFormattedValue) == "No Patient")
                        row.Row.SetField<int?>("patient_number", null);
                    using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
                    {
                        connection.Open();
                        string query = "UPDATE bed SET bed_number = ?, patient_number = ?, room_number = ?, ward_letter = ? WHERE (bed_number = ? AND room_number = ? AND ward_letter = ?)";
                        using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("bed_number", row.Row.Field<int>("bed_number"));

                            if (row.Row.Field<int?>("patient_number") == null)
                                command.Parameters.AddWithValue("patient_number", DBNull.Value);
                            else
                                command.Parameters.AddWithValue("patient_number", row.Row.Field<int?>("patient_number"));

                            command.Parameters.AddWithValue("room_number", row.Row.Field<int>("room_number"));
                            command.Parameters.AddWithValue("ward_letter", row.Row.Field<string>("ward_letter"));

                            command.Parameters.AddWithValue("bed_number_ck", row.Row.Field<int>("bed_number"));
                            command.Parameters.AddWithValue("room_number_ck", row.Row.Field<int>("room_number"));
                            command.Parameters.AddWithValue("ward_letter_ck", row.Row.Field<string>("ward_letter"));
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            //update the list of patient numbers.
            updateExistingPatients();
        }

        private void updateExistingPatients()
        {
            foreach (DataRowView rowView in bedBindingSource)
            {
                if (rowView.Row.Field<int?>("patient_number") != -1)
                {
                    DataRow r = rowView.Row;
                    if (r["patient_number"] != DBNull.Value)
                        existingPatientNumbers.Add(Convert.ToInt32(r["patient_number"]));
                }
            }
        }

        private void UpdatePatientNumberOptions()
        {

            patientTableAdapter.Fill(dataSet2.patient);

            //blank item to facilitate adding a bed with no patient
            patientsToBind.Add(new Patient());
            foreach (DataRow row in dataSet2.patient.Rows)
            {
                int patientNumber = Convert.ToInt32(row["patient_number"]);
                string firstName = Convert.ToString(row["first_name"]);
                string lastName = Convert.ToString(row["last_name"]);
                Patient patient = new Patient();
                patient.PatientNumber = patientNumber;
                patient.FirstName = firstName;
                patient.LastName = lastName;
                patientsToBind.Add(patient);
            }

            patientnumberDataGridViewTextBoxColumn.DataSource = patientsToBind;

            patientnumberDataGridViewTextBoxColumn.DisplayMember = "DisplayValue";
            patientnumberDataGridViewTextBoxColumn.ValueMember = "PatientNumber";

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = (DataRowView)e.Row.DataBoundItem;

            bedTableAdapter.Delete(row.Row.Field<int>("bed_number"), row.Row.Field<int>("patient_number"),
                row.Row.Field<int>("room_number"), row.Row.Field<string>("ward_letter"));
        }

    }
}
