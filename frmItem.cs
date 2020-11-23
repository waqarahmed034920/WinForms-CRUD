using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaskManagementSystem.Infrastructure.Interface;
using TaskManagementSystem.Infrastructure.Repositories;
using TaskManagementSystem.Model;

namespace TaskManagementSystem
{
    public partial class frmItem : Form
    {
        Item objItem = null;
        IRepository<Item> itemRepository = new ItemRepository();
        IRepository<Category> categoryRepository = new CategoryRepository();
        public frmItem()
        {
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {            
            List<Category> lst = categoryRepository.GetAll();
            lst.Insert(0, new Category() { Id = 0, Name = "Plaese select" });
            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.ValueMember = "Id";
            this.cmbCategory.DataSource = lst;
            RefreshGrid();
        }

        void clearForm()
        {
            this.cmbCategory.SelectedIndex = 0;
            this.txtBarcode.Text = string.Empty;
            this.txtDiscription.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtPrice.Text = string.Empty;
            this.txtQuantity.Text = string.Empty;
            this.txtReorder.Text = string.Empty;
        }
        void RefreshGrid()
        {
            this.dgItem.DataSource = this.itemRepository.GetAll();
        }



        bool Validatation()
        {
            if (this.cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a category.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                cmbCategory.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Validatation() == true)
            {
                try
                {
                    bool output;
                    string msg;
                    if (objItem == null)
                    {
                        objItem = new Item();
                        objItem.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
                        objItem.Name = txtName.Text;
                        objItem.Description = txtDiscription.Text;
                        objItem.Barcode = txtBarcode.Text;
                        objItem.ReOrderLevel = Convert.ToInt32(txtReorder.Text);
                        objItem.Price = Convert.ToDecimal(txtPrice.Text);
                        objItem.QuantityRemaining = Convert.ToInt32(txtQuantity.Text);
                        output = this.itemRepository.Insert(objItem);
                        msg = "Record saved successfully.";
                    }
                    else
                    {
                        objItem.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
                        objItem.Name = txtName.Text;
                        objItem.Description = txtDiscription.Text;
                        objItem.Barcode = txtBarcode.Text;
                        objItem.ReOrderLevel = Convert.ToInt32(txtReorder.Text);
                        objItem.Price = Convert.ToDecimal(txtPrice.Text);
                        objItem.QuantityRemaining = Convert.ToInt32(txtQuantity.Text);
                        output = this.itemRepository.Update(objItem);
                        msg = "Record updated successfully.";
                    }

                    if (output == true)
                    {
                        this.objItem = null;
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

        private void dgItem_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                dgItem.CurrentCell = dgItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                e.ContextMenuStrip = this.dgItemContextMenu;
            }

        }

       
        private void mnuEditItem_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgItem.CurrentRow.Cells[0].Value.ToString());

            this.objItem = this.itemRepository.GetSingle(id);
            if (objItem != null)
            {
                this.txtName.Text = objItem.Name;
                this.txtDiscription.Text = objItem.Description;
                this.txtBarcode.Text = objItem.Barcode;
                this.txtReorder.Text = objItem.ReOrderLevel.ToString();
                this.txtPrice.Text = objItem.Price.ToString();
                this.txtQuantity.Text = objItem.QuantityRemaining.ToString();
                var index = 0;
                var selecteditemIndex = 0;
                foreach(Category c in cmbCategory.Items)
                {
                    index++;
                    if (c.Id == objItem.CategoryId)
                    {
                        selecteditemIndex = index;
                        break;
                    }
                }
                this.cmbCategory.SelectedIndex = selecteditemIndex-1;
            }
            else
            {
                MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void mnuDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("This would delete the Item record. Are you sure?", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (choice == DialogResult.Yes)
            {

                int id = Convert.ToInt32(dgItem.CurrentRow.Cells[0].Value.ToString());
                bool ValueOutPut = this.itemRepository.Delete(id);
                if (ValueOutPut == true)

                {
                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
            }
        }
    }
}
