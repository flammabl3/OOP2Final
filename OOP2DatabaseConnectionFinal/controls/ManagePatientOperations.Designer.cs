namespace OOP2DatabaseConnectionFinal
{
    partial class ManagePatientOperations
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.procedureidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procedurenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatingstaffidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateperformedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datescheduledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proceduretypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wardletterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procedureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new OOP2DatabaseConnectionFinal.DataSet2();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.procedureTableAdapter = new OOP2DatabaseConnectionFinal.DataSet2TableAdapters.procedureTableAdapter();
            this.dataSet21 = new OOP2DatabaseConnectionFinal.DataSet2();
            this.patientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientTableAdapter = new OOP2DatabaseConnectionFinal.DataSet2TableAdapters.patientTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.procedureidDataGridViewTextBoxColumn,
            this.procedurenameDataGridViewTextBoxColumn,
            this.patientnumberDataGridViewTextBoxColumn,
            this.operatingstaffidDataGridViewTextBoxColumn,
            this.dateperformedDataGridViewTextBoxColumn,
            this.datescheduledDataGridViewTextBoxColumn,
            this.proceduretypeDataGridViewTextBoxColumn,
            this.roomnumberDataGridViewTextBoxColumn,
            this.wardletterDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.procedureBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(96, 123);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 288);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // procedureidDataGridViewTextBoxColumn
            // 
            this.procedureidDataGridViewTextBoxColumn.DataPropertyName = "procedure_id";
            this.procedureidDataGridViewTextBoxColumn.HeaderText = "procedure_id";
            this.procedureidDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.procedureidDataGridViewTextBoxColumn.Name = "procedureidDataGridViewTextBoxColumn";
            this.procedureidDataGridViewTextBoxColumn.ReadOnly = true;
            this.procedureidDataGridViewTextBoxColumn.Width = 200;
            // 
            // procedurenameDataGridViewTextBoxColumn
            // 
            this.procedurenameDataGridViewTextBoxColumn.DataPropertyName = "procedure_name";
            this.procedurenameDataGridViewTextBoxColumn.HeaderText = "procedure_name";
            this.procedurenameDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.procedurenameDataGridViewTextBoxColumn.Name = "procedurenameDataGridViewTextBoxColumn";
            this.procedurenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.procedurenameDataGridViewTextBoxColumn.Width = 200;
            // 
            // patientnumberDataGridViewTextBoxColumn
            // 
            this.patientnumberDataGridViewTextBoxColumn.DataPropertyName = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.HeaderText = "patient_number";
            this.patientnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.patientnumberDataGridViewTextBoxColumn.Name = "patientnumberDataGridViewTextBoxColumn";
            this.patientnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientnumberDataGridViewTextBoxColumn.Width = 200;
            // 
            // operatingstaffidDataGridViewTextBoxColumn
            // 
            this.operatingstaffidDataGridViewTextBoxColumn.DataPropertyName = "operating_staff_id";
            this.operatingstaffidDataGridViewTextBoxColumn.HeaderText = "operating_staff_id";
            this.operatingstaffidDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.operatingstaffidDataGridViewTextBoxColumn.Name = "operatingstaffidDataGridViewTextBoxColumn";
            this.operatingstaffidDataGridViewTextBoxColumn.ReadOnly = true;
            this.operatingstaffidDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateperformedDataGridViewTextBoxColumn
            // 
            this.dateperformedDataGridViewTextBoxColumn.DataPropertyName = "date_performed";
            this.dateperformedDataGridViewTextBoxColumn.HeaderText = "date_performed";
            this.dateperformedDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.dateperformedDataGridViewTextBoxColumn.Name = "dateperformedDataGridViewTextBoxColumn";
            this.dateperformedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateperformedDataGridViewTextBoxColumn.Width = 200;
            // 
            // datescheduledDataGridViewTextBoxColumn
            // 
            this.datescheduledDataGridViewTextBoxColumn.DataPropertyName = "date_scheduled";
            this.datescheduledDataGridViewTextBoxColumn.HeaderText = "date_scheduled";
            this.datescheduledDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.datescheduledDataGridViewTextBoxColumn.Name = "datescheduledDataGridViewTextBoxColumn";
            this.datescheduledDataGridViewTextBoxColumn.ReadOnly = true;
            this.datescheduledDataGridViewTextBoxColumn.Width = 200;
            // 
            // proceduretypeDataGridViewTextBoxColumn
            // 
            this.proceduretypeDataGridViewTextBoxColumn.DataPropertyName = "procedure_type";
            this.proceduretypeDataGridViewTextBoxColumn.HeaderText = "procedure_type";
            this.proceduretypeDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.proceduretypeDataGridViewTextBoxColumn.Name = "proceduretypeDataGridViewTextBoxColumn";
            this.proceduretypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.proceduretypeDataGridViewTextBoxColumn.Width = 200;
            // 
            // roomnumberDataGridViewTextBoxColumn
            // 
            this.roomnumberDataGridViewTextBoxColumn.DataPropertyName = "room_number";
            this.roomnumberDataGridViewTextBoxColumn.HeaderText = "room_number";
            this.roomnumberDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.roomnumberDataGridViewTextBoxColumn.Name = "roomnumberDataGridViewTextBoxColumn";
            this.roomnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.roomnumberDataGridViewTextBoxColumn.Width = 200;
            // 
            // wardletterDataGridViewTextBoxColumn
            // 
            this.wardletterDataGridViewTextBoxColumn.DataPropertyName = "ward_letter";
            this.wardletterDataGridViewTextBoxColumn.HeaderText = "ward_letter";
            this.wardletterDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.wardletterDataGridViewTextBoxColumn.Name = "wardletterDataGridViewTextBoxColumn";
            this.wardletterDataGridViewTextBoxColumn.ReadOnly = true;
            this.wardletterDataGridViewTextBoxColumn.Width = 200;
            // 
            // procedureBindingSource
            // 
            this.procedureBindingSource.DataMember = "procedure";
            this.procedureBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(186, 56);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(670, 27);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(396, 31);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(670, 77);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(396, 31);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.Visible = false;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Admission Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Discharge Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Patient ID";
            // 
            // procedureTableAdapter
            // 
            this.procedureTableAdapter.ClearBeforeFill = true;
            // 
            // dataSet21
            // 
            this.dataSet21.DataSetName = "DataSet2";
            this.dataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientBindingSource
            // 
            this.patientBindingSource.DataMember = "patient";
            this.patientBindingSource.DataSource = this.dataSet21;
            // 
            // patientTableAdapter
            // 
            this.patientTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(204, 446);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(366, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Mark Procedure as Completed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(626, 446);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(366, 44);
            this.button2.TabIndex = 8;
            this.button2.Text = "Discharge Patient";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 9;
            this.label4.Visible = false;
            // 
            // ManagePatientOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ManagePatientOperations";
            this.Size = new System.Drawing.Size(1154, 527);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.procedureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn procedureidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn procedurenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatingstaffidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateperformedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datescheduledDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proceduretypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wardletterDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource procedureBindingSource;
        private DataSet2 dataSet2;
        private DataSet2TableAdapters.procedureTableAdapter procedureTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource patientBindingSource;
        private DataSet2 dataSet21;
        private DataSet2TableAdapters.patientTableAdapter patientTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}
