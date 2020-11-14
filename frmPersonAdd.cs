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
    public partial class frmPersonAdd : Form
    {
        Person objPerson = null;
        // Event driven programming.
        public frmPersonAdd()
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
            if (txtFirstName.Text == string.Empty)
            {
                MessageBox.Show("Please enter first name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtFirstName.Focus();
            }
            else
            {
                if (txtLastName.Text == string.Empty)
                {
                    MessageBox.Show("Please enter lat name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtLastName.Focus();
                }

                else
                {
                    if (txtAddress.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter address", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        txtAddress.Focus();
                    }
                    else
                    {
                        if (txtPhone.Text == string.Empty)
                        {
                            MessageBox.Show("Please enter phone", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            txtPhone.Focus();
                        }
                        else
                        {
                            if (txtEmail.Text == string.Empty)
                            {
                                MessageBox.Show("Please enter email.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                txtEmail.Focus();
                            }
                            else
                            {
                                bool output;
                                string msg;
                                if(objPerson == null)
                                {
                                    objPerson = new Person();
                                    objPerson.FirstName = txtFirstName.Text;
                                    objPerson.LastName = txtLastName.Text;
                                    objPerson.Address = txtAddress.Text;
                                    objPerson.Phone = txtPhone.Text;
                                    objPerson.Email = txtEmail.Text;
                                    output = savePerson(objPerson);
                                    msg = "Record saved successfully.";
                                }
                                else 
                                {
                                    objPerson.FirstName = txtFirstName.Text;
                                    objPerson.LastName = txtLastName.Text;
                                    objPerson.Address = txtAddress.Text;
                                    objPerson.Phone = txtPhone.Text;
                                    objPerson.Email = txtEmail.Text;
                                    output = updateperson(objPerson);
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


                        }
                    }

                }


            }

        }

        private void clearForm()
        {
            this.txtFirstName.Text = string.Empty;
            this.txtLastName.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
        }

        private bool savePerson(Person objperson)
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into person(FirstName,lastName,Address,Phone,Email) values('" + objperson.FirstName + "','" + objperson.LastName + "','" + objperson.Address + "','" + objperson.Phone + "','" + objperson.Email + "')";

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

        private bool updateperson(Person objupdateper)
        {

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "update person set FirstName = '" + objupdateper.FirstName + "' ,lastName ='" + objupdateper.LastName + "',Address = '" + objupdateper.Address + "', phone= '" + objupdateper.Phone + "', Email='" + objupdateper.Email + "' where id = '" + objupdateper.Id + "'";

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

        private void frmperson_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        void RefreshGrid()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from person";
            SqlDataReader myreader = command.ExecuteReader();
            List<Person> personlist = new List<Person>();
            while (myreader.Read())
            {
                Person objperson = new Person();
                objperson.Id =  Convert.ToInt32(myreader["id"].ToString());
                objperson.FirstName = myreader["firstname"].ToString();
                objperson.LastName = myreader["lastname"].ToString();
                objperson.Address = myreader["address"].ToString();
                objperson.Phone = myreader["phone"].ToString();
                objperson.Email = myreader["email"].ToString();
                personlist.Add(objperson);
            }
            myreader.Close();
            connection.Close();
            dgPerson.DataSource = personlist;
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

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from person where id="+id.ToString();
            SqlDataReader myreader = command.ExecuteReader();

            while (myreader.Read())
            {
                objPerson = new Person();
                objPerson.Id = Convert.ToInt32(myreader["id"].ToString());
                objPerson.FirstName = myreader["firstname"].ToString();
                objPerson.LastName = myreader["lastname"].ToString();
                objPerson.Address = myreader["address"].ToString();
                objPerson.Phone = myreader["phone"].ToString();
                objPerson.Email = myreader["email"].ToString();
               
            }
            myreader.Close();
            connection.Close();
            if (objPerson != null)
            {
                this.txtFirstName.Text = objPerson.FirstName;
                this.txtLastName.Text = objPerson.LastName;
                this.txtAddress.Text = objPerson.Address;
                this.txtPhone.Text = objPerson.Phone;
                this.txtEmail.Text = objPerson.Email;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult choice =  MessageBox.Show("This would delete the Task record. Are you sure?", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (choice == DialogResult.Yes)
            {

                int id = Convert.ToInt32(dgPerson.CurrentRow.Cells[0].Value.ToString());
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "server=waqar-pc\\sqlexpress; Database=aptech; trusted_connection=true;";
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "delete  from person where id =" + id.ToString();

                int noOfRowsAffected = command.ExecuteNonQuery();
                connection.Close();
                if (noOfRowsAffected >= 1)
                {
                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
            }
        }
    }
    
}