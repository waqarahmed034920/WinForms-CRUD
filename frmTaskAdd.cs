using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskManagementSystem.Model;
using static System.Windows.Forms.DataGridView;

namespace TaskManagementSystem
{
    public partial class frmTaskAdd : Form
    {
        Task objTask = null;
        string ConnectionString = "Server=Localhost; Database=Aptech; Trusted_Connection=True; MultipleActiveResultSets=true";
        public frmTaskAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Are you show you want to leave the form?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTask.Text == string.Empty)
            {
                MessageBox.Show("please enter Task", "Required Field", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtTask.Focus();
            }
            else
            {
                if (txtdescription.Text == string.Empty)
                {
                    MessageBox.Show("please enter description ", "Required Field", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtdescription.Focus();
                }
                else
                {
                    if (txtstatus.Text == string.Empty)
                    {
                        MessageBox.Show("please enter status ", "Required Field", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        txtstatus.Focus();
                    }
                    else
                    {
                        bool returnedValue = false;
                        string msg;
                        if (objTask == null)
                        {
                            objTask = new Task();
                            objTask.TaskName = txtTask.Text;
                            objTask.Description = txtdescription.Text;
                            objTask.Status = txtstatus.Text;
                            returnedValue = SaveTask(objTask);
                            msg = "Task record added successfully";
                        }
                        else
                        {
                            objTask.TaskName = txtTask.Text;
                            objTask.Description = txtdescription.Text;
                            objTask.Status = txtstatus.Text;
                            returnedValue = UpdateTask(objTask);
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
                }
            }
        }

        private bool SaveTask(Task objTask)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Tasks(task,description,status) values('" + objTask.TaskName + "','" + objTask.Description + "','" + objTask.Status + "')";

                int noOfRowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UpdateTask(Task objUpdatTask)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "update Tasks set task = '" + objUpdatTask.TaskName + "', description = '" + objUpdatTask.Description + "', status = '" + objUpdatTask.Status + "' where id =  '" + objUpdatTask.Id + "'";

                int noOfRowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (noOfRowsAffected >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.ConnectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Tasks";
            SqlDataReader myReader = command.ExecuteReader();
            List<Task> tasklist = new List<Task>();
            while (myReader.Read())
            {
                Task objtask = new Task();
                objtask.Id = Convert.ToInt32(myReader["id"]);
                objtask.TaskName = myReader["task"].ToString();
                objtask.Description = myReader["description"].ToString();
                objtask.Status = myReader["status"].ToString();
                tasklist.Add(objtask);
            }

            myReader.Close();
            connection.Close();

            dgTasks.DataSource = tasklist;
        }

        private void mnuTaskEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgTasks.CurrentRow.Cells[0].Value.ToString());

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = this.ConnectionString;
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Tasks where id = " + id.ToString();
            SqlDataReader myReader = command.ExecuteReader();

            while (myReader.Read())
            {
                objTask = new Task();
                objTask.Id = Convert.ToInt32(myReader["id"]);
                objTask.TaskName = myReader["task"].ToString();
                objTask.Description = myReader["description"].ToString();
                objTask.Status = myReader["status"].ToString();
            }

            myReader.Close();
            connection.Close();

            if (objTask != null)
            {
                this.txtTask.Text = objTask.TaskName;
                this.txtdescription.Text = objTask.Description;
                this.txtstatus.Text = objTask.Status;
            }
        }

        private void mnuTaskDelete_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("This would delete the Task record. Are you sure?", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgTasks.CurrentRow.Cells[0].Value.ToString());
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from Tasks where id = " + id.ToString();
                int noOfRowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (noOfRowsAffected >= 1)
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
                e.ContextMenuStrip = dgViewContextMenu;
            }
        }
    }
}
