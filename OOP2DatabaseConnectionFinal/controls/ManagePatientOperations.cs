using OOP2DatabaseConnectionFinal.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OOP2DatabaseConnectionFinal
{

    /* fairly elaborate way to update the 
     * date displayed when we update the database. Because the patient info (like discharge date) is stored as a list in the class,
     * we need to repopulate it when we update some info. Then we need to reassign the new list of patients to the combobox.
     * Lastly, we need to set the properties of the combobox again, but disable the event handlers for the datetimepickers.
     * This is because the datetimepickers will update the database when they are changed. Whenever we change the selected patient, it will update the database,
     * which is not what we want. I have worked around this by disabling the event handlers using changedViaUser whenever we change the current patient.
     * It will also eliminate unwanted updates when the datetimepickers are changed when we reset the datasource for the patient combobox.
     * */
    public partial class ManagePatientOperations : BasicControl
    {
        List<Patient> patientsToBind;
        List<Room> roomsToBind;
        List<Tuple<string, string>> procedureTypes;

        bool changedViaUser = false;
        public ManagePatientOperations()
        {
            procedureTypes = new List<Tuple<string, string>>();
            patientsToBind = new List<Patient>();
            roomsToBind = new List<Room>();
            InitializeComponent();

            procedureTypes.Add(new Tuple<string, string>("C", "Care"));
            procedureTypes.Add(new Tuple<string, string>("S", "Surgery"));

            proceduretypeDataGridViewTextBoxColumn.DataSource = procedureTypes;
            proceduretypeDataGridViewTextBoxColumn.ValueMember = "Item1";
            proceduretypeDataGridViewTextBoxColumn.DisplayMember = "Item2";


            dateTimePicker2.Enabled = false;
            dateTimePicker2.Visible = false;

            label4.Visible = false;

            BindPatients();

            comboBox1.DataSource = null;
            comboBox1.DataSource = patientsToBind;

            comboBox1.DisplayMember = "DisplayValue";
            comboBox1.ValueMember = "PatientNumber";

            isLoaded = true;

            comboBox1_SelectedValueChanged(null, EventArgs.Empty);
            comboBox1.SelectedIndex = 0;


        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;

            changedViaUser = true;

            Patient selectedPatient = (Patient)comboBox1.SelectedItem;
            dateTimePicker1.Value = selectedPatient.AdmissionDate;
            if (selectedPatient.AdmissionDate != null)
            {
                dateTimePicker1.Value = Convert.ToDateTime(selectedPatient.AdmissionDate);
                dateTimePicker2.Visible = true;
                dateTimePicker2.Enabled = true;
            } 
            else
                dateTimePicker1.Value = DateTime.Now;

            if (selectedPatient.DischargeDate != null)
                dateTimePicker2.Value = Convert.ToDateTime(selectedPatient.DischargeDate);
            else
            {
                dateTimePicker2.Enabled = false;

                dateTimePicker2.Value = dateTimePicker2.MaxDate;
                dateTimePicker2.Visible = false;
            }

            procedureTableAdapter.FillByPatientID(dataSet2.procedure, Convert.ToInt32(comboBox1.SelectedValue));

            changedViaUser = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker2.Visible = true;
            dateTimePicker2.Enabled = true;

            updateDate("UPDATE patient SET `discharge_date`=? WHERE patient_number = ?", dateTimePicker2.Value);
            var connection = OdbcSingleton.Instance;
            string query = "UPDATE `bed` SET `patient_number` = NULL WHERE `patient_number` = ?";

            using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
            {
                command.Parameters.AddWithValue("patient_number", comboBox1.SelectedValue);
                command.ExecuteNonQuery();
            }
        }

        private void updateDate(string query, DateTime time)
        {
            var connection = OdbcSingleton.Instance;

            using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
            {
                command.Parameters.AddWithValue("discharge_date", time);
                command.Parameters.AddWithValue("patient_number", comboBox1.SelectedValue);

                command.ExecuteNonQuery();
            }

            BindPatients();

            isLoaded = false;
            comboBox1.DataSource = null;
            comboBox1.DataSource = patientsToBind;
            comboBox1.DisplayMember = "DisplayValue";
            comboBox1.ValueMember = "PatientNumber";
            isLoaded = true;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isLoaded)
                    return;

                if (changedViaUser)
                {
                    return;
                }
                if (dateTimePicker1.Value > dateTimePicker2.Value)
                    throw new Exception("Admission date cannot be after discharge date!");
                updateDate("UPDATE patient SET `admission_date`=? WHERE patient_number = ?", dateTimePicker1.Value);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                            "Data Entry Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isLoaded)
                    return;
                if (changedViaUser)
                {
                    return;
                }
                if (dateTimePicker1.Value > dateTimePicker2.Value)
                    throw new Exception("Admission date cannot be after discharge date!");
                updateDate("UPDATE patient SET `discharge_date`=? WHERE patient_number = ?", dateTimePicker2.Value);
            } catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                            "Data Entry Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                selectedRow.Cells[4].Value = DateTime.Now;

                var connection = OdbcSingleton.Instance;
                string query = "UPDATE `procedure` SET `date_performed` = ? WHERE `procedure_id` = ?";
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    command.Parameters.AddWithValue("date_performed", DateTime.Now);
                    command.Parameters.AddWithValue("procedure_id", selectedRow.Cells[0].Value);

                    command.ExecuteNonQuery();
                }

            } else
            {
                
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                button1.Enabled = true;
            } else
            {
                button1.Enabled = false;
            }
        }

        private void BindPatients()
        {
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
                patient.AdmissionDate = Convert.ToDateTime(row["admission_date"]);
                if (row["discharge_date"] == DBNull.Value)
                    patient.DischargeDate = null;
                else
                    patient.DischargeDate = Convert.ToDateTime(row["discharge_date"]);
                patientsToBind.Add(patient);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errorHeader = dataGridView1.Columns[e.ColumnIndex].HeaderText;

            MessageBox.Show($"Error in {errorHeader}, Row Number {e.RowIndex + 1}: {e.Exception.Message}",
                            "Data Entry Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
