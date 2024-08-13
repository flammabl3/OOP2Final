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
    // This is the base class from which each page inherits. It has a method to place itself inside a TabControl.
    // isLoaded is an attribute which is used to restrict some operations until the page has fully loaded, such as updating controls.
    public partial class BasicControl : UserControl
    {
        public bool isLoaded = false;
        public BasicControl()
        {
            InitializeComponent();
        }

        public void PlaceInTabControl(TabControl tabControl, TabPage page)
        {
            tabControl.SelectedTab = page;
            tabControl.SelectedTab.Controls.Add(this);
            this.Dock = DockStyle.Fill;
        }
    }
}
