using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskManagementSystem.Infrastructure.Interface;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Model;
using static System.Windows.Forms.DataGridView;

namespace TaskManagementSystem
{
    public partial class frmTaskAdd : Form
    {
        Task objTask = null;
        IRepository<Task> repository = new TaskRepository();
        public frmTaskAdd()
        {
            InitializeComponent();
        }

        void clearForm()
        {
            txtTask.Text = string.Empty;
            txtdescription.Text = string.Empty;
            txtstatus.Text = string.Empty;
            txtTask.Focus();
        }

        private void frmTaskAdd_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        void RefreshGrid()
        {
            dgTasks.DataSource = this.repository.GetAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Are you show you want to leave the form?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                this.Close();
            }
        }

        bool Validation()
        {
            if (txtTask.Text == string.Empty)
            {
                MessageBox.Show("please enter Task", "Required Field", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtTask.Focus();
                return false;
            }
            else
            {
                if (txtdescription.Text == string.Empty)
                {
                    MessageBox.Show("please enter description ", "Required Field", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtdescription.Focus();
                    return false;
                }
                else
                {
                    if (txtstatus.Text == string.Empty)
                    {
                        MessageBox.Show("please enter status ", "Required Field", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        txtstatus.Focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validation() == true)
            {
                try
                {

                    bool returnedValue = false;
                    string msg;
                    if (objTask == null)
                    {
                        objTask = new Task();
                        objTask.TaskName = txtTask.Text;
                        objTask.Description = txtdescription.Text;
                        objTask.Status = txtstatus.Text;
                        returnedValue = this.repository.Insert(objTask);
                        msg = "Task record added successfully";
                    }
                    else
                    {
                        objTask.TaskName = txtTask.Text;
                        objTask.Description = txtdescription.Text;
                        objTask.Status = txtstatus.Text;
                        returnedValue = this.repository.Update(objTask);
                        msg = "Task record updated successfully";
                    }
                    if (returnedValue == true)
                    {
                        this.objTask = null;
                        MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearForm();
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuTaskEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgTasks.CurrentRow.Cells[0].Value.ToString());

            this.objTask = this.repository.GetSingle(id);

            if (objTask != null)
            {
                this.txtTask.Text = objTask.TaskName;
                this.txtdescription.Text = objTask.Description;
                this.txtstatus.Text = objTask.Status;
            }
            else
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuTaskDelete_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("This would delete the Task record. Are you sure?", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgTasks.CurrentRow.Cells[0].Value.ToString());
                bool output = this.repository.Delete(id);
                if (output == true)
                {
                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
            }
        }

        private void dgTasks_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgTasks.CurrentCell = dgTasks.Rows[e.RowIndex].Cells[e.ColumnIndex];
                e.ContextMenuStrip = dgTasksContextMenu;
            }

        }

        private void dgTasksContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
