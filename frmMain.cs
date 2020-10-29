using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaskManagementSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuPersonAdd_Click(object sender, EventArgs e)
        {
            frmPersonAdd objPersonAdd = new frmPersonAdd();
            objPersonAdd.MdiParent = this;
            objPersonAdd.Show();
        }

        private void mnuTaskAdd_Click(object sender, EventArgs e)
        {
            frmTaskAdd objTaskAdd = new frmTaskAdd();
            objTaskAdd.MdiParent = this;
            objTaskAdd.Show();
            objTaskAdd.WindowState = FormWindowState.Maximized;
        }

    }
}
