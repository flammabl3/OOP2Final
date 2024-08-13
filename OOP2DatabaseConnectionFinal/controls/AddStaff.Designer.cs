namespace OOP2DatabaseConnectionFinal.controls
{
    partial class AddStaff
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
            this.staffTable = new System.Windows.Forms.DataGridView();
            this.staffidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.contactnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicalstaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new OOP2DatabaseConnectionFinal.DataSet2();
            this.medical_staffTableAdapter = new OOP2DatabaseConnectionFinal.DataSet2TableAdapters.medical_staffTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.staffTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalstaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // staffTable
            // 
            this.staffTable.AllowUserToResizeColumns = false;
            this.staffTable.AllowUserToResizeRows = false;
            this.staffTable.AutoGenerateColumns = false;
            this.staffTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staffTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.staffidDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.contactnumberDataGridViewTextBoxColumn,
            this.contactemailDataGridViewTextBoxColumn});
            this.staffTable.DataSource = this.medicalstaffBindingSource;
            this.staffTable.Location = new System.Drawing.Point(0, 0);
            this.staffTable.Margin = new System.Windows.Forms.Padding(4);
            this.staffTable.Name = "staffTable";
            this.staffTable.RowHeadersWidth = 82;
            this.staffTable.RowTemplate.Height = 33;
            this.staffTable.Size = new System.Drawing.Size(1152, 523);
            this.staffTable.TabIndex = 1;
            this.staffTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.staffTable_DataError);
            this.staffTable.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.staffTable_DefaultValuesNeeded);
            this.staffTable.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.staffTable_RowValidated);
            this.staffTable.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.staffTable_UserDeletingRow);
            // 
            // staffidDataGridViewTextBoxColumn
            // 
            this.staffidDataGridViewTextBoxColumn.DataPropertyName = "staff_id";
            this.staffidDataGridViewTextBoxColumn.HeaderText = "Staff ID";
            this.staffidDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.staffidDataGridViewTextBoxColumn.Name = "staffidDataGridViewTextBoxColumn";
            this.staffidDataGridViewTextBoxColumn.Width = 200;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Staff Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.titleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.titleDataGridViewTextBoxColumn.Width = 200;
            // 
            // contactnumberDataGridViewTextBoxColumn
            // 
            this.contactnumberDataGridViewTextBoxColumn.DataPropertyName = "contact_number";
            this.contactnumberDataGridViewTextBoxColumn.HeaderText = "Phone No.";
            this.contactnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.contactnumberDataGridViewTextBoxColumn.Name = "contactnumberDataGridViewTextBoxColumn";
            this.contactnumberDataGridViewTextBoxColumn.Width = 200;
            // 
            // contactemailDataGridViewTextBoxColumn
            // 
            this.contactemailDataGridViewTextBoxColumn.DataPropertyName = "contact_email";
            this.contactemailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            this.contactemailDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.contactemailDataGridViewTextBoxColumn.Name = "contactemailDataGridViewTextBoxColumn";
            this.contactemailDataGridViewTextBoxColumn.Width = 200;
            // 
            // medicalstaffBindingSource
            // 
            this.medicalstaffBindingSource.DataMember = "medical_staff";
            this.medicalstaffBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // medical_staffTableAdapter
            // 
            this.medical_staffTableAdapter.ClearBeforeFill = true;
            // 
            // AddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.staffTable);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AddStaff";
            this.Size = new System.Drawing.Size(1152, 527);
            this.Load += new System.EventHandler(this.AddStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staffTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalstaffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView staffTable;
        private System.Windows.Forms.BindingSource medicalstaffBindingSource;
        private DataSet2 dataSet2;
        private DataSet2TableAdapters.medical_staffTableAdapter medical_staffTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactemailDataGridViewTextBoxColumn;
    }
}
