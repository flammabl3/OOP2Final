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
            this.patientTable = new System.Windows.Forms.DataGridView();
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new OOP2DatabaseConnectionFinal.DataSet1();
            this.patientBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new OOP2DatabaseConnectionFinal.DataSet2();
            this.patientTableAdapter = new OOP2DatabaseConnectionFinal.DataSet1TableAdapters.patientTableAdapter();
            this.patientnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middlenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admission_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discharge_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.patientTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // patientTable
            // 
            this.patientTable.AutoGenerateColumns = false;
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
            this.patientTable.Location = new System.Drawing.Point(0, 0);
            this.patientTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.patientTable.Name = "patientTable";
            this.patientTable.RowHeadersWidth = 82;
            this.patientTable.RowTemplate.Height = 33;
            this.patientTable.Size = new System.Drawing.Size(1152, 523);
            this.patientTable.TabIndex = 0;
            this.patientTable.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.patientTable.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
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
            // patientBindingSource1
            // 
            this.patientBindingSource1.DataMember = "patient";
            this.patientBindingSource1.DataSource = this.dataSet2;
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
            // patientnumberDataGridViewTextBoxColumn
            // 
            this.patientnumberDataGridViewTextBoxColumn.DataPropertyName = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.HeaderText = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.patientnumberDataGridViewTextBoxColumn.Name = "patientnumberDataGridViewTextBoxColumn";
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "first_name";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            // 
            // middlenameDataGridViewTextBoxColumn
            // 
            this.middlenameDataGridViewTextBoxColumn.DataPropertyName = "middle_name";
            this.middlenameDataGridViewTextBoxColumn.HeaderText = "middle_name";
            this.middlenameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.middlenameDataGridViewTextBoxColumn.Name = "middlenameDataGridViewTextBoxColumn";
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "last_name";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            // 
            // contactnumberDataGridViewTextBoxColumn
            // 
            this.contactnumberDataGridViewTextBoxColumn.DataPropertyName = "contact_number";
            this.contactnumberDataGridViewTextBoxColumn.HeaderText = "contact_number";
            this.contactnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.contactnumberDataGridViewTextBoxColumn.Name = "contactnumberDataGridViewTextBoxColumn";
            // 
            // admission_date
            // 
            this.admission_date.DataPropertyName = "admission_date";
            this.admission_date.HeaderText = "admission_date";
            this.admission_date.MinimumWidth = 10;
            this.admission_date.Name = "admission_date";
            this.admission_date.ReadOnly = true;
            // 
            // discharge_date
            // 
            this.discharge_date.DataPropertyName = "discharge_date";
            this.discharge_date.HeaderText = "discharge_date";
            this.discharge_date.MinimumWidth = 10;
            this.discharge_date.Name = "discharge_date";
            this.discharge_date.ReadOnly = true;
            // 
            // PatientManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.patientTable);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PatientManagement";
            this.Size = new System.Drawing.Size(1152, 527);
            this.Load += new System.EventHandler(this.PatientManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patientTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView patientTable;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource patientBindingSource1;
        private DataSet2 dataSet2;
        private DataSet1TableAdapters.patientTableAdapter patientTableAdapter;
        private System.Windows.Forms.BindingSource patientBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middlenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn admission_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn discharge_date;
    }
}
