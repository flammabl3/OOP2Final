using OOP2DatabaseConnectionFinal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            //create and use an OdbcConnection using the connectionString that we use for mariadb.
            using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
            {
                connection.Open();

                //create a select query and use the patient?s number as a parameter. Return if there are more than 0 results. 
                string query = "SELECT COUNT(*) FROM medical_staff WHERE staff_id = ?";
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    command.Parameters.AddWithValue("patient_number", patientNo);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
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

           
            using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                string query = "";
                if (row.Row.RowState == DataRowState.Added)
                {
                    query = "INSERT INTO `medical_staff`(`staff_id`, `first_name`, `last_name`, `contact_number`, `contact_email`, `title`) VALUES " +
                        "(?,?,?,?,?,?)";
                } else if (row.Row.RowState == DataRowState.Modified)
                {
                    query = "UPDATE `medical_staff` SET `staff_id`=?,`first_name`=?,`last_name`=?," +
                        "`contact_number`=?,`contact_email`=?,`title`=? WHERE staff_id = ?";
                }
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    command.Parameters.AddWithValue("staff_id", row.Row.Field<int>("staff_id"));

                    command.Parameters.AddWithValue("first_name", row.Row.Field<string>("first_name"));
                    command.Parameters.AddWithValue("last_name", row.Row.Field<string>("last_name"));
                    command.Parameters.AddWithValue("contact_number", row.Row.Field<string>("contact_number"));

                    command.Parameters.AddWithValue("contact_email", row.Row.Field<string>("contact_email"));
                    command.Parameters.AddWithValue("title", staffTable.Rows[e.RowIndex].Cells[3].Value);

                    command.Parameters.AddWithValue("staff_id_ck", row.Row.Field<int>("staff_id"));

                    command.ExecuteNonQuery();
                }
            }

        }

        private void staffTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!isLoaded)
                return;

            var row = (DataRowView)e.Row.DataBoundItem;



            using (var connection = new System.Data.Odbc.OdbcConnection(OOP2DatabaseConnectionFinal.Properties.Settings.Default.ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM medical_staff WHERE staff_id = ?";
                using (var command = new System.Data.Odbc.OdbcCommand(query, connection))
                {
                    command.Parameters.AddWithValue("staff_id", row.Row.Field<int>("staff_id"));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
