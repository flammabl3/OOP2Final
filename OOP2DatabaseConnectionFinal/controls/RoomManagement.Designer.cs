namespace OOP2DatabaseConnectionFinal
{
    partial class RoomManagement
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.wardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new OOP2DatabaseConnectionFinal.DataSet2();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wardTableAdapter = new OOP2DatabaseConnectionFinal.DataSet2TableAdapters.wardTableAdapter();
            this.roomTableAdapter = new OOP2DatabaseConnectionFinal.DataSet2TableAdapters.roomTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bed_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.room_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ward_letter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bedBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bedBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientTableAdapter = new OOP2DatabaseConnectionFinal.DataSet2TableAdapters.patientTableAdapter();
            this.bedTableAdapter = new OOP2DatabaseConnectionFinal.DataSet2TableAdapters.bedTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.wardBindingSource;
            this.comboBox1.DisplayMember = "ward_name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(374, 27);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "ward_letter";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // wardBindingSource
            // 
            this.wardBindingSource.DataMember = "ward";
            this.wardBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ward";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Room";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.roomBindingSource;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(690, 27);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(156, 33);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox2_SelectedValueChanged);
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataMember = "room";
            this.roomBindingSource.DataSource = this.dataSet2;
            // 
            // wardTableAdapter
            // 
            this.wardTableAdapter.ClearBeforeFill = true;
            // 
            // roomTableAdapter
            // 
            this.roomTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bed_number,
            this.room_number,
            this.ward_letter,
            this.patientnumberDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bedBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(40, 92);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1082, 369);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            // 
            // bed_number
            // 
            this.bed_number.DataPropertyName = "bed_number";
            this.bed_number.HeaderText = "bed_number";
            this.bed_number.MinimumWidth = 10;
            this.bed_number.Name = "bed_number";
            this.bed_number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bed_number.Width = 80;
            // 
            // room_number
            // 
            this.room_number.DataPropertyName = "room_number";
            this.room_number.HeaderText = "room_number";
            this.room_number.MinimumWidth = 10;
            this.room_number.Name = "room_number";
            this.room_number.Width = 80;
            // 
            // ward_letter
            // 
            this.ward_letter.DataPropertyName = "ward_letter";
            this.ward_letter.HeaderText = "ward_letter";
            this.ward_letter.MinimumWidth = 10;
            this.ward_letter.Name = "ward_letter";
            this.ward_letter.Width = 80;
            // 
            // patientnumberDataGridViewTextBoxColumn
            // 
            this.patientnumberDataGridViewTextBoxColumn.DataPropertyName = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.DataSource = this.bedBindingSource;
            this.patientnumberDataGridViewTextBoxColumn.DisplayMember = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.HeaderText = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.patientnumberDataGridViewTextBoxColumn.Name = "patientnumberDataGridViewTextBoxColumn";
            this.patientnumberDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.patientnumberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.patientnumberDataGridViewTextBoxColumn.ValueMember = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.Width = 200;
            // 
            // bedBindingSource
            // 
            this.bedBindingSource.DataMember = "bed";
            this.bedBindingSource.DataSource = this.dataSet2;
            // 
            // bedBindingSource1
            // 
            this.bedBindingSource1.DataMember = "bed";
            this.bedBindingSource1.DataSource = this.dataSet2;
            // 
            // patientBindingSource
            // 
            this.patientBindingSource.DataMember = "patient";
            this.patientBindingSource.DataSource = this.dataSet2;
            // 
            // patientTableAdapter
            // 
            this.patientTableAdapter.ClearBeforeFill = true;
            // 
            // bedTableAdapter
            // 
            this.bedTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(434, 465);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Error: Patient already has a bed.";
            this.label3.Visible = false;
            // 
            // RoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RoomManagement";
            this.Size = new System.Drawing.Size(1152, 527);
            this.Load += new System.EventHandler(this.RoomManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource wardBindingSource;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private DataSet2TableAdapters.wardTableAdapter wardTableAdapter;
        private DataSet2TableAdapters.roomTableAdapter roomTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource patientBindingSource;
        private DataSet2TableAdapters.patientTableAdapter patientTableAdapter;
        private System.Windows.Forms.BindingSource bedBindingSource;
        private DataSet2TableAdapters.bedTableAdapter bedTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bedBindingSource1;
        private System.Windows.Forms.BindingSource bedBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn bed_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn room_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn ward_letter;
        private System.Windows.Forms.DataGridViewComboBoxColumn patientnumberDataGridViewTextBoxColumn;
    }
}
