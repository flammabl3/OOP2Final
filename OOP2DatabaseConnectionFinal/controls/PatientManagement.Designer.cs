namespace OOP2DatabaseConnectionFinal
{
    partial class PatientManagement
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new OOP2DatabaseConnectionFinal.DataSet1();
            this.dataSet2 = new OOP2DatabaseConnectionFinal.DataSet2();
            this.patientTableAdapter = new OOP2DatabaseConnectionFinal.DataSet1TableAdapters.patientTableAdapter();
            this.patientTable = new System.Windows.Forms.DataGridView();
            this.patientnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middlenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admission_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discharge_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientTable)).BeginInit();
            this.SuspendLayout();
            // 
            // patientBindingSource
            // 
            this.patientBindingSource.DataMember = "patient";
            this.patientBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientTableAdapter
            // 
            this.patientTableAdapter.ClearBeforeFill = true;
            // 
            // patientTable
            // 
            this.patientTable.AllowUserToResizeColumns = false;
            this.patientTable.AllowUserToResizeRows = false;
            this.patientTable.AutoGenerateColumns = false;
            this.patientTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.patientTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patientnumberDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.middlenameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.contactnumberDataGridViewTextBoxColumn,
            this.admission_date,
            this.discharge_date});
            this.patientTable.DataSource = this.patientBindingSource;
            this.patientTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patientTable.Location = new System.Drawing.Point(0, 0);
            this.patientTable.Margin = new System.Windows.Forms.Padding(4);
            this.patientTable.Name = "patientTable";
            this.patientTable.RowHeadersWidth = 82;
            this.patientTable.RowTemplate.Height = 33;
            this.patientTable.Size = new System.Drawing.Size(1172, 543);
            this.patientTable.TabIndex = 1;
            this.patientTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.patientTable_DataError);
            this.patientTable.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.patientTable.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            this.patientTable.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.patientTable_UserDeletingRow);
            // 
            // patientnumberDataGridViewTextBoxColumn
            // 
            this.patientnumberDataGridViewTextBoxColumn.DataPropertyName = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.HeaderText = "Patient ID";
            this.patientnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.patientnumberDataGridViewTextBoxColumn.Name = "patientnumberDataGridViewTextBoxColumn";
            this.patientnumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.Width = 161;
            // 
            // middlenameDataGridViewTextBoxColumn
            // 
            this.middlenameDataGridViewTextBoxColumn.DataPropertyName = "middle_name";
            this.middlenameDataGridViewTextBoxColumn.HeaderText = "Middle Name";
            this.middlenameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.middlenameDataGridViewTextBoxColumn.Name = "middlenameDataGridViewTextBoxColumn";
            this.middlenameDataGridViewTextBoxColumn.Width = 183;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.Width = 160;
            // 
            // contactnumberDataGridViewTextBoxColumn
            // 
            this.contactnumberDataGridViewTextBoxColumn.DataPropertyName = "contact_number";
            this.contactnumberDataGridViewTextBoxColumn.HeaderText = "Phone Number";
            this.contactnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.contactnumberDataGridViewTextBoxColumn.Name = "contactnumberDataGridViewTextBoxColumn";
            this.contactnumberDataGridViewTextBoxColumn.Width = 184;
            // 
            // admission_date
            // 
            this.admission_date.DataPropertyName = "admission_date";
            this.admission_date.HeaderText = "Admission Date";
            this.admission_date.MinimumWidth = 10;
            this.admission_date.Name = "admission_date";
            this.admission_date.ReadOnly = true;
            this.admission_date.Width = 190;
            // 
            // discharge_date
            // 
            this.discharge_date.DataPropertyName = "discharge_date";
            this.discharge_date.HeaderText = "discharge_date";
            this.discharge_date.MinimumWidth = 10;
            this.discharge_date.Name = "discharge_date";
            this.discharge_date.ReadOnly = true;
            this.discharge_date.Visible = false;
            this.discharge_date.Width = 205;
            // 
            // PatientManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.patientTable);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PatientManagement";
            this.Size = new System.Drawing.Size(1172, 543);
            this.Load += new System.EventHandler(this.PatientManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataSet1 dataSet1;
        private DataSet2 dataSet2;
        private DataSet1TableAdapters.patientTableAdapter patientTableAdapter;
        private System.Windows.Forms.BindingSource patientBindingSource;
        private System.Windows.Forms.DataGridView patientTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middlenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn admission_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn discharge_date;
    }
}
