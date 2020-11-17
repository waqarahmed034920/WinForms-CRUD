namespace TaskManagementSystem
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaskAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPerson,
            this.mnuTask,
            this.categoryToolStripMenuItem,
            this.itemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuPerson
            // 
            this.mnuPerson.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPersonAdd,
            this.mnuPersonSearch});
            this.mnuPerson.Name = "mnuPerson";
            this.mnuPerson.Size = new System.Drawing.Size(55, 20);
            this.mnuPerson.Text = "Person";
            // 
            // mnuPersonAdd
            // 
            this.mnuPersonAdd.Name = "mnuPersonAdd";
            this.mnuPersonAdd.Size = new System.Drawing.Size(109, 22);
            this.mnuPersonAdd.Text = "Add";
            this.mnuPersonAdd.Click += new System.EventHandler(this.mnuPersonAdd_Click);
            // 
            // mnuPersonSearch
            // 
            this.mnuPersonSearch.Name = "mnuPersonSearch";
            this.mnuPersonSearch.Size = new System.Drawing.Size(109, 22);
            this.mnuPersonSearch.Text = "Search";
            // 
            // mnuTask
            // 
            this.mnuTask.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTaskAdd});
            this.mnuTask.Name = "mnuTask";
            this.mnuTask.Size = new System.Drawing.Size(43, 20);
            this.mnuTask.Text = "Task";
            // 
            // mnuTaskAdd
            // 
            this.mnuTaskAdd.Name = "mnuTaskAdd";
            this.mnuTaskAdd.Size = new System.Drawing.Size(180, 22);
            this.mnuTaskAdd.Text = "Add";
            this.mnuTaskAdd.Click += new System.EventHandler(this.mnuTaskAdd_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManageCategory});
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.categoryToolStripMenuItem.Text = "Category";
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.itemToolStripMenuItem.Text = "Item";
            // 
            // mnuManageCategory
            // 
            this.mnuManageCategory.Name = "mnuManageCategory";
            this.mnuManageCategory.Size = new System.Drawing.Size(180, 22);
            this.mnuManageCategory.Text = "Manage";
            this.mnuManageCategory.Click += new System.EventHandler(this.mnuManageCategory_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuPerson;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuTask;
        private System.Windows.Forms.ToolStripMenuItem mnuTaskAdd;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuManageCategory;
    }
}