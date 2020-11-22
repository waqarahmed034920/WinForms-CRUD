using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskManagementSystem.Model;
using TaskManagementSystem.Infrastructure.Repositories;
using static System.Windows.Forms.DataGridView;
using System.Data.SqlClient;
using TaskManagementSystem.Infrastructure.Interface;

namespace TaskManagementSystem
{
    public partial class frmCategory : Form
    {
        Category objcategory = null;
        IRepository<Category> repository = new CategoryRepository();
        public frmCategory()
        {
            InitializeComponent();
        }

        void clearForm()
        {
            this.txtName.Text = string.Empty;
            this.txtDiscription.Text = string.Empty;
            txtName.Focus();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        void RefreshGrid()
        {

            dgCategory.DataSource = this.repository.GetAll();
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
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Please enter lat name", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            else
            {
                if (txtDiscription.Text == string.Empty)
                {
                    MessageBox.Show("Please enter address", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtDiscription.Focus();
                    return false;
                }
                else
                {
                    return true;
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
                    switch (objcategory)
                    {
                        case null:
                            objcategory = new Category();
                            objcategory.Name = txtName.Text;
                            objcategory.Discription = txtDiscription.Text;

                            output = this.repository.Insert(objcategory);
                            msg = "Record saved successfully.";
                            break;
                        default:
                            objcategory.Name = txtName.Text;
                            objcategory.Discription = txtDiscription.Text;

                            output = this.repository.Update(objcategory);
                            msg = "Record updated successfully.";
                            break;
                    }

                    if (output == true)
                    {
                        this.objcategory = null;
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgCategory.CurrentRow.Cells[0].Value.ToString());

            this.objcategory = this.repository.GetSingle(id);
            if (objcategory != null)
            {
                this.txtName.Text = objcategory.Name;
                this.txtDiscription.Text = objcategory.Discription;
            }
            else
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgCategory_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgCategory.CurrentCell = dgCategory.Rows[e.RowIndex].Cells[e.ColumnIndex];
                e.ContextMenuStrip = dgCategoryContextMenu;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("This would delete the category record. Are you sure?", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (choice == DialogResult.Yes)
            {

                int id = Convert.ToInt32(dgCategory.CurrentRow.Cells[0].Value.ToString());
                bool ValueOutPut = this.repository.Delete(id);
                if (ValueOutPut == true)
                {
                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
            }
        }
    }
}
