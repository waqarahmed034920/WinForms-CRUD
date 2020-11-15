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
using TaskManagementSystem.Infrastructure.Repositories;
namespace TaskManagementSystem
{
    public partial class frmPersonAdd : Form
    {
        Person objPerson = null;
        PersonRepositories repositories = new PersonRepositories();
        // Event driven programming.
        public frmPersonAdd()
        {
            InitializeComponent();
        }
         void clearForm()
        {
            this.txtFirstName.Text = string.Empty;
            this.txtLastName.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            txtFirstName.Focus();
        }
        private void frmperson_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        void RefreshGrid()
        {

            dgPerson.DataSource = this.repositories.GetAll();
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
            if (txtFirstName.Text == string.Empty)
            {
                MessageBox.Show("Please enter first name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return false;
            }
            else
            {
                if (txtLastName.Text == string.Empty)
                {
                    MessageBox.Show("Please enter lat name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtLastName.Focus();
                    return false;
                }

                else
                {
                    if (txtAddress.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter address", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        txtAddress.Focus();
                        return false;
                    }
                    else
                    {
                        if (txtPhone.Text == string.Empty)
                        {
                            MessageBox.Show("Please enter phone", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            txtPhone.Focus();
                            return false;
                        }
                        else
                        {
                            if (txtEmail.Text == string.Empty)
                            {
                                MessageBox.Show("Please enter email.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                txtEmail.Focus();
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
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


                      bool output;
                      string msg;
                      if (objPerson == null)
                      {
                          objPerson = new Person();
                          objPerson.FirstName = txtFirstName.Text;
                          objPerson.LastName = txtLastName.Text;
                          objPerson.Address = txtAddress.Text;
                          objPerson.Phone = txtPhone.Text;
                          objPerson.Email = txtEmail.Text;
                          output = this.repositories.insert(objPerson);
                          msg = "Record saved successfully.";
                      }
                      else
                      {
                         objPerson.FirstName = txtFirstName.Text;
                         objPerson.LastName = txtLastName.Text;
                         objPerson.Address = txtAddress.Text;
                         objPerson.Phone = txtPhone.Text;
                         objPerson.Email = txtEmail.Text;
                         output = this.repositories.update(objPerson);
                         msg = "Record updated successfully.";
                      }

                      if (output == true)
                      {
                         this.objPerson = null;
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
                    

                


            

        

       

        

       

       
       

        private void dgPerson_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgPerson.CurrentCell = dgPerson.Rows[e.RowIndex].Cells[e.ColumnIndex];
                e.ContextMenuStrip = dgPersonContextMenu;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgPerson.CurrentRow.Cells[0].Value.ToString());

            this.objPerson = this.repositories.Getsingle(id);
            if (objPerson != null)
            {
                this.txtFirstName.Text = objPerson.FirstName;
                this.txtLastName.Text = objPerson.LastName;
                this.txtAddress.Text = objPerson.Address;
                this.txtPhone.Text = objPerson.Phone;
                this.txtEmail.Text = objPerson.Email;
            }
            else
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult choice =  MessageBox.Show("This would delete the Task record. Are you sure?", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (choice == DialogResult.Yes)
            {

                int id = Convert.ToInt32(dgPerson.CurrentRow.Cells[0].Value.ToString());
                bool ValueOutPut = this.repositories.Delete(id);
                if(ValueOutPut ==true)
               
                {
                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
            }
        }
    }
    
}