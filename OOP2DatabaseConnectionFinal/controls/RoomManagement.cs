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

namespace OOP2DatabaseConnectionFinal
{
    public partial class RoomManagement : BasicControl
    {
        List<Ward> wardsToBind;
        List<Room> roomsToBind;
        public RoomManagement() : base()
        {
            wardsToBind = new List<Ward>();
            roomsToBind = new List<Room>();
            InitializeComponent();
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {
            //fill the dataset defined by the designer and fill the rows table.
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
                    roomsToBind.Add(room);
                } 
            }

            comboBox2.DataSource = roomsToBind;

            //display value represents our composite PK for the room.
            comboBox2.DisplayMember = "DisplayValue";
            comboBox2.ValueMember = "DisplayValue";

        }

        /*
         To make database operations without an adapter, use OdbcConnection
        using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
            }

        This should eventually be  made a singleton from the mainpage class and passed into each usercontrol.
         */
    }
}
