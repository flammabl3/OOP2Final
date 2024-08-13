using OOP2DatabaseConnectionFinal.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2DatabaseConnectionFinal
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            tabControl1_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void PatientsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientManagement patientManagement = new PatientManagement();
            patientManagement.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == patientTab)
            {
                PatientManagement patientManagement = new PatientManagement();

                patientManagement.PlaceInTabControl(tabControl1, patientTab);
            }
            else if (tabControl1.SelectedTab == roomTab)
            {
                RoomManagement roomManagement = new RoomManagement();

                roomManagement.PlaceInTabControl(tabControl1, roomTab);
            }

            else if (tabControl1.SelectedTab == scheduleTab)
            {
                ScheduleProcedure schedule = new ScheduleProcedure();

                schedule.PlaceInTabControl(tabControl1, scheduleTab);
            }
            else if (tabControl1.SelectedTab == PatientOperations)
            {
                ManagePatientOperations mpo = new ManagePatientOperations();

                mpo.PlaceInTabControl(tabControl1, PatientOperations);
            }
            else if (tabControl1.SelectedTab == ManageStaff)
            {
                AddStaff addstaff = new AddStaff();

                addstaff.PlaceInTabControl(tabControl1, ManageStaff);
            }
        }
    }
}
