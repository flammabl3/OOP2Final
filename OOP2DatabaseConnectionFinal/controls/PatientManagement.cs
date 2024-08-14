using OOP2DatabaseConnectionFinal.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


/* Author: Harry Jung
 * Inserts, deletes, or updates patients stored at the hospital.
 * Patient ID is randomly generated and checked using a select statement to ensure it is not a duplicate. This logic to generate primary keys is found in
 * the alreadyExists method and can be found in most other classes;
 * SQL statements are executed with an OdbcConnection singleton. The OdbcConnection class connects to the MySQL database. A query is defined by
 * the code and then parameters are added to match the query. OdbcConnection does not support named parameters, so they are added in order.
 * In any tab where the user is editing some rows, the content is updated when the row is deleted or the
 * RowValidated event is triggered, indicating the user has edited and clicked off that row. 
 * A patient's admission date will automatically be set to the current time. If a row is deleted, the patient will be marked as discharged on the current datetime.
 * Truly deleting a patient can only be done by a database admin, since we should not be able to erase a patient's visit from the hospital.
 * To edit the admission or discharge dates, there is a separate screen, patient operations.
 */

namespace OOP2DatabaseConnectionFinal
{
    public partial class PatientManagement : BasicControl
    {
        public PatientManagement() : base()
        {
            InitializeComponent();
            //custom query, only retrieve patients that have not been discharged (discharge_date IS NULL)
            this.patientTableAdapter.FillBy(this.dataSet1.patient);
        }

        private void PatientManagement_Load(object sender, EventArgs e)
        {
            patientTable.Refresh();
        }

        //A row is validated when a new row is added and the user clicks off.
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //Checks if the row is an empty row. Don't add this row.
            if (patientTable.Rows[e.RowIndex].IsNewRow)
                return;

            //cast the data at the index of the row added and captured by the event handler. Cast it to a DataRowView.
            var row = (DataRowView)patientTable.Rows[e.RowIndex].DataBoundItem;

            
            if (row != null)
            {

                var connection = OdbcSingleton.Instance;

                string query = "";

                //if the row was added by the user, use an insert. If it was an existing row that was modified, update.
                if (row.Row.RowState == DataRowState.Added) {
                    query = "INSERT INTO `patient`(`patient_number`, `first_name`, `middle_name`, `last_name`, `contact_number`, `admission_date`, `discharge_date`) " +
                            "VALUES (?, ?, ?, ?, ?, ?, ?)";
                } else if (row.Row.RowState == DataRowState.Modified) {
                    query = "UPDATE `patient` SET `patient_number`=?,`first_name`=?,`middle_name`=?,`last_name`=?,`contact_number`=?,`admission_date`=?,`discharge_date`=? WHERE `patient_number` = ?";
                } else
                {
                    return;
                }
                
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    //OdbcAdapter and OdbcConnection use a type called DBNull instead of null.
                    // Names are not validated too much, since someone should not be denied from the hospital on the basis of a weird name.

                    string phoneNumber = row.Row.Field<string>("contact_number");

                    //if any characters other than plus, digits, brackets, hyphens, or whitespapce are in the phone number, throw exception.
                    if (Regex.IsMatch(phoneNumber, @"[^0-9\-\(\)\+ ]"))
                    {
                        throw new Exception("Invalid characters in phone number!");
                    }


                    //replace non numeric, leave plus for phone extensions
                    phoneNumber = Regex.Replace(phoneNumber, @"[^0-9\+]", "");

                    // A phone number, with nothing but a plus, a country code, and an 11 digit number, cannot be more than 16 characters.
                    if (phoneNumber.Length > 16)
                    {
                        throw new Exception("Phone number exceeds max length!");
                    }

                    string middleName = row.Row.Field<string>("middle_name");
                    command.Parameters.AddWithValue("patient_number", row.Row.Field<int>("patient_number"));
                    command.Parameters.AddWithValue("first_name", row.Row.Field<string>("first_name"));
                    if (middleName != null)
                        command.Parameters.AddWithValue("middle_name", middleName);
                    else
                        command.Parameters.AddWithValue("middle_name", DBNull.Value);
                    command.Parameters.AddWithValue("last_name", row.Row.Field<string>("last_name"));
                    command.Parameters.AddWithValue("contact_number", phoneNumber);
                    command.Parameters.AddWithValue("admission_date", DateTime.Now);
                    command.Parameters.AddWithValue("discharge_date", DBNull.Value);
                    command.Parameters.AddWithValue("patient_number_ck", row.Row.Field<int>("patient_number"));
                    command.ExecuteNonQuery();
                        
                }

                
            }

            //accept changes to set the RowState to Unchanged, allowing further modifications to work properly.
            row.EndEdit();
            row.Row.AcceptChanges();

        }

        //query and see if a patient already exists.
        private bool alreadyExists(int patientNo)
        {
            //create and use an OdbcConnection using the singleton and connectionstring that we use for mariadb.
            var connection = OdbcSingleton.Instance;
           
            //create a select query and use the patient's number as a parameter. Return if there are more than 0 results, indicating an existing PK.
            string query = "SELECT COUNT(*) FROM patient WHERE patient_number = ?";
            using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
            {
                command.Parameters.AddWithValue("patient_number", patientNo);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            Random random = new Random();
            int min = 10000000;
            int max = 99999999;
            int randomNumber = random.Next(min, max + 1);

            //generate numbers until we don't have a duplicate. in all likelihood, it will NOT be a duplicate.
            while (alreadyExists(randomNumber))
            {
                randomNumber = random.Next(min, max + 1);
            }

            e.Row.Cells[0].Value = randomNumber;
            e.Row.Cells[5].Value = Convert.ToString(DateTime.Now);
            e.Row.Cells[6].Value = "";
        }

        // if an error occurs with the data entered, the datagridview itself should be able to handle it.
        private void patientTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errorHeader = patientTable.Columns[e.ColumnIndex].HeaderText;

            MessageBox.Show($"Error in {errorHeader}, Row Number {e.RowIndex + 1}: {e.Exception.Message}",
                            "Data Entry Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        // if a patient was deleted, simply discharge them.
        private void patientTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = (DataRowView)e.Row.DataBoundItem;

            var connection = OdbcSingleton.Instance;
            string query = "UPDATE `patient` SET `discharge_date` = ? WHERE `patient_number` = ?";


            using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
            {
                command.Parameters.AddWithValue("discharge_date", DateTime.Now);
                command.Parameters.AddWithValue("patient_number", row.Row.Field<int>("patient_number"));
                command.ExecuteNonQuery();

            }

            query = "UPDATE `bed` SET `patient_number` = NULL WHERE `patient_number` = ?";


            using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
            {
                command.Parameters.AddWithValue("patient_number", row.Row.Field<int>("patient_number"));
                command.ExecuteNonQuery();

            }

        }

    }
}
