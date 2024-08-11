namespace OOP2DatabaseConnectionFinal
{
    partial class MainPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.patientTab = new System.Windows.Forms.TabPage();
            this.roomTab = new System.Windows.Forms.TabPage();
            this.scheduleTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.patientTab);
            this.tabControl1.Controls.Add(this.roomTab);
            this.tabControl1.Controls.Add(this.scheduleTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1169, 574);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // patientTab
            // 
            this.patientTab.Location = new System.Drawing.Point(8, 39);
            this.patientTab.Name = "patientTab";
            this.patientTab.Padding = new System.Windows.Forms.Padding(3);
            this.patientTab.Size = new System.Drawing.Size(1153, 527);
            this.patientTab.TabIndex = 0;
            this.patientTab.Text = "Patient Management";
            this.patientTab.UseVisualStyleBackColor = true;
            // 
            // roomTab
            // 
            this.roomTab.Location = new System.Drawing.Point(8, 39);
            this.roomTab.Name = "roomTab";
            this.roomTab.Padding = new System.Windows.Forms.Padding(3);
            this.roomTab.Size = new System.Drawing.Size(1153, 527);
            this.roomTab.TabIndex = 1;
            this.roomTab.Text = "Room Management";
            this.roomTab.UseVisualStyleBackColor = true;
            // 
            // scheduleTab
            // 
            this.scheduleTab.Location = new System.Drawing.Point(8, 39);
            this.scheduleTab.Name = "scheduleTab";
            this.scheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleTab.Size = new System.Drawing.Size(1153, 527);
            this.scheduleTab.TabIndex = 2;
            this.scheduleTab.Text = "Schedule Procedure";
            this.scheduleTab.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 578);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainPage";
            this.Text = "Home Page";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage patientTab;
        private System.Windows.Forms.TabPage roomTab;
        private System.Windows.Forms.TabPage scheduleTab;
    }
}