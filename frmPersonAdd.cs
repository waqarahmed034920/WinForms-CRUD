using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaskManagementSystem
{
    public partial class frmPersonAdd : Form
    {
        // Event driven programming.
        public frmPersonAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == string.Empty)
            {
                MessageBox.Show("Please enter first name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtFirstName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this is click Event of btncancel");
        }
    }
}
