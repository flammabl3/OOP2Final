using OOP2DatabaseConnectionFinal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP2DatabaseConnectionFinal
{
    public partial class PatientManagement : BasicControl
    {
        public PatientManagement() : base()
        {
            InitializeComponent();
        }

        private void PatientManagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet11.patient' table. You can move, or remove it, as needed.;
            this.patientTableAdapter.Fill(this.dataSet1.patient);

        }

        //A row is validated when a new row is added and the user clicks off.
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //Checks if the row is an empty row. Don't add this row.
            if (patientTable.Rows[e.RowIndex].IsNewRow)
                return;

            //cast the data at the index of the row added and captured by the event handler. Cast it to a DataRowView.
            var row = (DataRowView)patientTable.Rows[e.RowIndex].DataBoundItem;

            if (row != null && row.Row.RowState == DataRowState.Added)
            {

                using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();

                    // procedure is a reserved keyword, have to escape it! Won't rename the table because the dataSet is already quite
                    // developed.
                    string query = "INSERT INTO `patient`(`patient_number`, `first_name`, `middle_name`, `last_name`, `contact_number`, `admission_date`, `discharge_date`) " +
                        "VALUES (?, ?, ?, ?, ?, ?, ?)";
                    using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                    {

                        string middleName = row.Row.Field<string>("middle_name");
                        command.Parameters.AddWithValue("patient_number", row.Row.Field<int>("patient_number"));
                        command.Parameters.AddWithValue("first_name", row.Row.Field<string>("first_name"));
                        if (middleName != null)
                            command.Parameters.AddWithValue("middle_name", middleName);
                        else
                            command.Parameters.AddWithValue("middle_name", DBNull.Value);
                        command.Parameters.AddWithValue("last_name", row.Row.Field<string>("last_name"));
                        command.Parameters.AddWithValue("contact_number", row.Row.Field<string>("contact_number"));
                        command.Parameters.AddWithValue("admission_date", DateTime.Now);
                        command.Parameters.AddWithValue("discharge_date", DBNull.Value);
                        command.ExecuteNonQuery();
                        
                    }
                }
            }

        }

        //query and see if a patient already exists.
        private bool alreadyExists(int patientNo)
        {
            //create and use an OdbcConnection using the connectionString that we use for mariadb.
            using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
            {
                connection.Open();

                //create a select query and use the patient's number as a parameter. Return if there are more than 0 results. 
                string query = "SELECT COUNT(*) FROM patient WHERE patient_number = ?";
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    command.Parameters.AddWithValue("patient_number", patientNo);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            Random random = new Random();
            int min = 10000000;
            int max = 99999999;
            int randomNumber = random.Next(min, max + 1);

            //generate numbers until we don't have a duplicate. in all likelyhood, it will NOT be a duplicate.
            while (alreadyExists(randomNumber))
            {
                randomNumber = random.Next(min, max + 1);
            }

            e.Row.Cells[0].Value = randomNumber;
            e.Row.Cells[5].Value = Convert.ToString(DateTime.Now);
            e.Row.Cells[6].Value = "";
        }
    }
}
