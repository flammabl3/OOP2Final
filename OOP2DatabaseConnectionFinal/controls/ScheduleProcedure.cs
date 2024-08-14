using OOP2DatabaseConnectionFinal.Classes;
using OOP2DatabaseConnectionFinal.DataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


/* Author: Harry Jung
 * This page inserts a row into the procedure table, with an assigned patient and surgeon, but no date of completion.
 * Surgeries should be marked complete in the patient operations tab.
 * Only rooms marked as M will show up in the options.
 * Insert is done with OdbcConnection.
 */

namespace OOP2DatabaseConnectionFinal
{
    public partial class ScheduleProcedure : BasicControl
    {
        List<MedicalStaff> staffToBind;
        List<Patient> patientsToBind;
        List<Room> roomsToBind;
        public ScheduleProcedure()
        {
            staffToBind = new List<MedicalStaff>();
            patientsToBind = new List<Patient>();
            roomsToBind = new List<Room>();
            InitializeComponent();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;

            staffToBind.Clear();
            medical_staffTableAdapter.Fill(dataSet2.medical_staff);

            foreach (DataRow row in dataSet2.medical_staff)
            {
                int staffID = Convert.ToInt32(row[0]);
                string firstName = Convert.ToString(row[1]);
                string lastName = Convert.ToString(row[2]);
                string phoneNumber = Convert.ToString(row[3]);
                string email = Convert.ToString(row[4]);
                char staffType = Convert.ToChar(row[5]);

                //Only doctors can perform surgery, not nurses!
                if (comboBox2.Text == "Surgery")
                {
                    if (staffType == 'D')
                    {
                        Doctor doctor = new Doctor(staffID, firstName, lastName, phoneNumber, email);
                        staffToBind.Add(doctor);
                    }
                }
                else if (comboBox2.Text == "Care")
                {
                    if (staffType == 'N')
                    {
                        Nurse nurse = new Nurse(staffID, firstName, lastName, phoneNumber, email);
                        staffToBind.Add(nurse);
                    }
                }
            }
            comboBox3.DataSource = null;
            comboBox3.DataSource = staffToBind;
            comboBox3.DisplayMember = "DisplayValue";
            comboBox3.ValueMember = "StaffID";

            patientsToBind.Clear();
            patientTableAdapter.Fill(dataSet2.patient);

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

            comboBox4.DataSource = null;
            comboBox4.DataSource = patientsToBind;

            comboBox4.DisplayMember = "DisplayValue";
            comboBox4.ValueMember = "PatientNumber";

            roomsToBind.Clear();
            comboBox5.DataSource = null;

            if (comboBox2.Text == "Surgery")
            {
                roomTableAdapter.Fill(dataSet2.room);
                foreach (DataRow row in dataSet2.room.Rows)
                {
                    int roomNumber = Convert.ToInt32(row[0]);
                    char wardLetter = Convert.ToChar(row[1]);
                    string roomName = Convert.ToString(row[2]);
                    char roomType = Convert.ToChar(row[3]);

                    //only display medical rooms, can't do surgery in a patient's room!
                    if (roomType == 'M')
                    {
                        Room room = new MedicalRoom(roomNumber, wardLetter, roomName);
                        roomsToBind.Add(room);
                    }
                }

                comboBox5.DataSource = roomsToBind;

                comboBox5.DisplayMember = "DisplayValue";
                comboBox5.ValueMember = "RoomNumber";
            }
        }

        private void ScheduleProcedure_Load(object sender, EventArgs e)
        {
            isLoaded = true;
            label7.Visible = false;

            List<ProcedureTypes> procedureTypes = new List<ProcedureTypes>
            {
                new ProcedureTypes("Surgery", 'S'),
                new ProcedureTypes("Care", 'C')
            };

            comboBox2.DataSource = procedureTypes;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Type";

            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            label7.Visible = false;

            string procedureName = textBox1.Text;
            int patientNumber = Convert.ToInt32(comboBox4.SelectedValue);
            int operatingStaffID = Convert.ToInt32(comboBox3.SelectedValue);
            DateTime? datePerformed = null;
            DateTime dateScheduled = dateTimePicker1.Value;

            string procedureType = comboBox2.Text;

            var connection = OdbcSingleton.Instance;

            // procedure is a reserved keyword, have to escape it! Won't rename the table because the database is already quite
            // developed, renaming a table could cause headaches.
            string query = "INSERT INTO `procedure`(`procedure_id`, `procedure_name`, `patient_number`, `operating_staff_id`, `date_performed`, `date_scheduled`, `procedure_type`, `room_number`, `ward_letter`) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            try
            {
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    command.Parameters.AddWithValue("procedure_id", randomNumber());

                    if (Regex.IsMatch(procedureName, @"[^a-zA-Z0-9 ]"))
                    {
                        throw new Exception("Alphanumeric characters in the procedure name only please!");
                    } 

                    if (procedureName.Trim().Length == 0)
                        throw new Exception("Procedure must have a name!");

                    if (operatingStaffID == 0)
                        throw new Exception("Please select a staff member to perform the operation!");

                    command.Parameters.AddWithValue("procedure_name", procedureName.Trim());
                    command.Parameters.AddWithValue("patient_number", patientNumber);
                    command.Parameters.AddWithValue("operating_staff_id", operatingStaffID);
                    command.Parameters.AddWithValue("date_performed", datePerformed.HasValue ? (object)datePerformed.Value : DBNull.Value);
                    command.Parameters.AddWithValue("date_scheduled", dateScheduled);
                    command.Parameters.AddWithValue("procedure_type", procedureType);


                    if (procedureType == "Surgery")
                    {
                        Room selectedRoom = (Room)comboBox5.SelectedItem;

                        string wardLetter = Convert.ToString(selectedRoom.WardLetter);
                        int roomNumber = selectedRoom.RoomNumber;

                        command.Parameters.AddWithValue("room_number", roomNumber);
                        command.Parameters.AddWithValue("ward_letter", wardLetter);

                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command.Parameters.AddWithValue("room_number", DBNull.Value);
                        command.Parameters.AddWithValue("ward_letter", DBNull.Value);
                        command.ExecuteNonQuery();
                    }

                    label7.Text = "Success!";
                    label7.Visible = true;
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                                "Data Entry Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private bool alreadyExists(int procedureId)
        {
            using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM `procedure` WHERE procedure_id = ?";
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    command.Parameters.AddWithValue("procedure_id", procedureId);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private int randomNumber()
        {
            Random random = new Random();
            int min = 10000000;
            int max = 999999999;
            int randomNumber = random.Next(min, max + 1);

            while (alreadyExists(randomNumber))
            {
                randomNumber = random.Next(min, max + 1);
            }

            return randomNumber;
        }

    }
}
