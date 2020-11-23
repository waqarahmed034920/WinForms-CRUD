namespace TaskManagementSystem
{
    partial class frmItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgItem = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtReorder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblDiscription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDiscription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.dgItemContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgItem
            // 
            this.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItem.Location = new System.Drawing.Point(0, 0);
            this.dgItem.Name = "dgItem";
            this.dgItem.Size = new System.Drawing.Size(416, 450);
            this.dgItem.TabIndex = 12;
            this.dgItem.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgItem_CellContextMenuStripNeeded);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(15, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 55);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(259, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(182, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.txtReorder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.lblDiscription);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtDiscription);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 217);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(129, 16);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(197, 21);
            this.cmbCategory.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Quantity Remaining";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(130, 186);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(198, 20);
            this.txtQuantity.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Re order level";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(130, 158);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(198, 20);
            this.txtPrice.TabIndex = 11;
            // 
            // txtReorder
            // 
            this.txtReorder.Location = new System.Drawing.Point(130, 130);
            this.txtReorder.Name = "txtReorder";
            this.txtReorder.Size = new System.Drawing.Size(197, 20);
            this.txtReorder.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Barcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Category";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(130, 102);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(198, 20);
            this.txtBarcode.TabIndex = 7;
            // 
            // lblDiscription
            // 
            this.lblDiscription.AutoSize = true;
            this.lblDiscription.Location = new System.Drawing.Point(10, 78);
            this.lblDiscription.Name = "lblDiscription";
            this.lblDiscription.Size = new System.Drawing.Size(56, 13);
            this.lblDiscription.TabIndex = 5;
            this.lblDiscription.Text = "Discription";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            // 
            // txtDiscription
            // 
            this.txtDiscription.Location = new System.Drawing.Point(129, 74);
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.Size = new System.Drawing.Size(198, 20);
            this.txtDiscription.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(129, 46);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 20);
            this.txtName.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgItem);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 13;
            // 
            // dgItemContextMenu
            // 
            this.dgItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditItem,
            this.mnuDeleteItem});
            this.dgItemContextMenu.Name = "dgItemContextMenu";
            this.dgItemContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // mnuEditItem
            // 
            this.mnuEditItem.Name = "mnuEditItem";
            this.mnuEditItem.Size = new System.Drawing.Size(180, 22);
            this.mnuEditItem.Text = "Edit";
            this.mnuEditItem.Click += new System.EventHandler(this.mnuEditItem_Click);
            // 
            // mnuDeleteItem
            // 
            this.mnuDeleteItem.Name = "mnuDeleteItem";
            this.mnuDeleteItem.Size = new System.Drawing.Size(180, 22);
            this.mnuDeleteItem.Text = "Delete";
            this.mnuDeleteItem.Click += new System.EventHandler(this.mnuDeleteItem_Click);
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmItem";
            this.Text = "frmItem";
            this.Load += new System.EventHandler(this.frmItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItem)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.dgItemContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtReorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblDiscription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDiscription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip dgItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEditItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
    }
}