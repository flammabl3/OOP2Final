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
        private PatientManagement patientManagement;
        private RoomManagement roomManagement;
        private ScheduleProcedure schedule;
        private ManagePatientOperations mpo;
        private AddStaff addstaff;
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

        //dispose of existing screens and create a new one to refresh.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == patientTab)
            {
                patientManagement?.Dispose();
                patientManagement = new PatientManagement();
                patientManagement.PlaceInTabControl(tabControl1, patientTab);
            }
            else if (tabControl1.SelectedTab == roomTab)
            {
                roomManagement?.Dispose();
                roomManagement = new RoomManagement();
                roomManagement.PlaceInTabControl(tabControl1, roomTab);
            }
            else if (tabControl1.SelectedTab == scheduleTab)
            {
                schedule?.Dispose();
                schedule = new ScheduleProcedure();
                schedule.PlaceInTabControl(tabControl1, scheduleTab);
            }
            else if (tabControl1.SelectedTab == PatientOperations)
            {
                mpo?.Dispose();
                mpo = new ManagePatientOperations();
                mpo.PlaceInTabControl(tabControl1, PatientOperations);
            }
            else if (tabControl1.SelectedTab == ManageStaff)
            {
                addstaff?.Dispose();
                addstaff = new AddStaff();
                addstaff.PlaceInTabControl(tabControl1, ManageStaff);
            }
        }
    }
}
