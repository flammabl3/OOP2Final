using OOP2DatabaseConnectionFinal.Classes;
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

namespace OOP2DatabaseConnectionFinal.controls
{
    public partial class AddStaff : BasicControl
    {

        List<Tuple<string, string>> titles;

        public AddStaff()
        {
            titles = new List<Tuple<string, string>>();
            InitializeComponent();
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            medical_staffTableAdapter.Fill(dataSet2.medical_staff);
    
            isLoaded = true;
            titles.Add(new Tuple<string, string>("D", "Doctor"));
            titles.Add(new Tuple<string, string>("N", "Nurse"));

            titleDataGridViewTextBoxColumn.DataSource = titles;
            titleDataGridViewTextBoxColumn.ValueMember = "Item1";
            titleDataGridViewTextBoxColumn.DisplayMember = "Item2";
        }


        private void staffTable_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (!isLoaded)
                return;

            Random random = new Random();
            int min = 100000000;
            int max = 999999999;
            int randomNumber = random.Next(min, max + 1);

            //generate numbers until we don?t have a duplicate. in all likelyhood, it will NOT be a duplicate.
            while (alreadyExists(randomNumber))
            {
                randomNumber = random.Next(min, max + 1);
            }
            e.Row.Cells[0].Value = randomNumber;

        }

        private bool alreadyExists(int patientNo)
        {
            //create and use an OdbcConnection singleton using the connectionString that we use for mariadb.
            var connection = OdbcSingleton.Instance;

            string query = "SELECT COUNT(*) FROM medical_staff WHERE staff_id = ?";
            using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
            {
                command.Parameters.AddWithValue("patient_number", patientNo);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        //modifying an added row is troublesome. Perhaps manually change the RowState to something else?
        private void staffTable_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (staffTable.Rows[e.RowIndex].IsNewRow || Convert.ToInt32(staffTable.Rows[e.RowIndex].Cells[0].Value) == 0)
                return;

            if (!isLoaded)
                return;

            var row = (DataRowView)staffTable.Rows[e.RowIndex].DataBoundItem;

            if (row.Row.RowState != DataRowState.Added && row.Row.RowState != DataRowState.Modified)
                return;


            var connection = OdbcSingleton.Instance;
            string query = "";

            try
            {
                if (row.Row.RowState == DataRowState.Added)
                {
                    query = "INSERT INTO `medical_staff`(`staff_id`, `first_name`, `last_name`, `contact_number`, `contact_email`, `title`) VALUES " +
                        "(?,?,?,?,?,?)";
                }
                else if (row.Row.RowState == DataRowState.Modified)
                {
                    query = "UPDATE `medical_staff` SET `staff_id`=?,`first_name`=?,`last_name`=?," +
                        "`contact_number`=?,`contact_email`=?,`title`=? WHERE staff_id = ?";
                }
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    string phoneNo = row.Row.Field<string>("contact_number");
                    string contactEmail = row.Row.Field<string>("contact_email");

                    //if any characters other than plus, digits, brackets, hyphens, or whitespapce are in the phone number, throw exception.
                    if (Regex.IsMatch(phoneNo, @"[^0-9\-\(\)\+ ]"))
                    {
                        throw new Exception("Invalid characters in phone number!");
                    }


                    //replace non numeric, leave plus for phone extensions
                    phoneNo = Regex.Replace(phoneNo, @"[^0-9\+]", "");

                    // A phone number, with nothing but a plus, a country code, and an 11 digit number, cannot be more than 16 characters.
                    if (phoneNo.Length > 16) {
                        throw new Exception("Phone number exceeds max length!");
                    }

                    command.Parameters.AddWithValue("staff_id", row.Row.Field<int>("staff_id"));

                    command.Parameters.AddWithValue("first_name", row.Row.Field<string>("first_name").Trim());
                    command.Parameters.AddWithValue("last_name", row.Row.Field<string>("last_name").Trim());
                    command.Parameters.AddWithValue("contact_number", phoneNo.Trim());


                    //email should only contain valid characters and should have a domain name after an @ sign.
                    if (!Regex.IsMatch(contactEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                    {
                        throw new Exception("Email is not valid!");
                    }

                    command.Parameters.AddWithValue("contact_email", contactEmail.Trim());
                    command.Parameters.AddWithValue("title", staffTable.Rows[e.RowIndex].Cells[3].Value);

                    command.Parameters.AddWithValue("staff_id_ck", row.Row.Field<int>("staff_id"));

                    command.ExecuteNonQuery();

                    //accept the changes.
                    row.Row.AcceptChanges();
                    row.EndEdit();
                }
            } catch (Exception ex)
            {
                row.Row.Delete();
                MessageBox.Show($"Error: {ex.Message}",
                            "Data Entry Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

        }

        private void staffTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!isLoaded)
                return;

            var row = (DataRowView)e.Row.DataBoundItem;



            var connection = OdbcSingleton.Instance;

            string query = "DELETE FROM medical_staff WHERE staff_id = ?";
            using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
            {
                command.Parameters.AddWithValue("staff_id", row.Row.Field<int>("staff_id"));

                command.ExecuteNonQuery();
            }
            
        }

        // Display a message box when an exception is thrown by the DataGridView
        private void staffTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errorHeader = staffTable.Columns[e.ColumnIndex].HeaderText;

            MessageBox.Show($"Error in {errorHeader}, Row Number {e.RowIndex + 1}: {e.Exception.Message}",
                            "Data Entry Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

    }
}
