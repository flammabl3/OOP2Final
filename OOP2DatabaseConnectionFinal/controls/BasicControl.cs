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
    public partial class BasicControl : UserControl
    {
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
