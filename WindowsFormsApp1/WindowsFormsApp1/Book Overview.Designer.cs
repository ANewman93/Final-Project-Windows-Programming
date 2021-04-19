namespace WindowsFormsApp1
{
    partial class Book_Overview
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
            this.OrderIDList = new System.Windows.Forms.ListView();
            this.OrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.placeNewOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placeNewOrderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StoresDropDown = new System.Windows.Forms.ComboBox();
            this.BooksOnOrderList = new System.Windows.Forms.ListView();
            this.TitleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaymentTermsLabel = new System.Windows.Forms.Label();
            this.PaymentTermsTextBox = new System.Windows.Forms.TextBox();
            this.BooksOnOrderLabel = new System.Windows.Forms.Label();
            this.removeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderIDList
            // 
            this.OrderIDList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderID});
            this.OrderIDList.GridLines = true;
            this.OrderIDList.HideSelection = false;
            this.OrderIDList.Location = new System.Drawing.Point(19, 57);
            this.OrderIDList.Name = "OrderIDList";
            this.OrderIDList.Size = new System.Drawing.Size(155, 361);
            this.OrderIDList.TabIndex = 0;
            this.OrderIDList.UseCompatibleStateImageBehavior = false;
            this.OrderIDList.View = System.Windows.Forms.View.Details;
            this.OrderIDList.Click += new System.EventHandler(this.OrderIDList_Click);
            // 
            // OrderID
            // 
            this.OrderID.Text = "Order ID";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.placeNewOrderToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(654, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // placeNewOrderToolStripMenuItem
            // 
            this.placeNewOrderToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.placeNewOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.placeNewOrderToolStripMenuItem1,
            this.removeOrderToolStripMenuItem});
            this.placeNewOrderToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeNewOrderToolStripMenuItem.Name = "placeNewOrderToolStripMenuItem";
            this.placeNewOrderToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.placeNewOrderToolStripMenuItem.Text = "Order Control";
            // 
            // placeNewOrderToolStripMenuItem1
            // 
            this.placeNewOrderToolStripMenuItem1.Name = "placeNewOrderToolStripMenuItem1";
            this.placeNewOrderToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.placeNewOrderToolStripMenuItem1.Text = "Place New Order";
            this.placeNewOrderToolStripMenuItem1.Click += new System.EventHandler(this.placeNewOrderToolStripMenuItem1_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(12, 22);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // StoresDropDown
            // 
            this.StoresDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StoresDropDown.FormattingEnabled = true;
            this.StoresDropDown.Location = new System.Drawing.Point(19, 30);
            this.StoresDropDown.Name = "StoresDropDown";
            this.StoresDropDown.Size = new System.Drawing.Size(623, 21);
            this.StoresDropDown.TabIndex = 2;
            this.StoresDropDown.SelectedIndexChanged += new System.EventHandler(this.StoresDropDown_SelectedIndexChanged);
            // 
            // BooksOnOrderList
            // 
            this.BooksOnOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleID,
            this.Title,
            this.Quantity});
            this.BooksOnOrderList.FullRowSelect = true;
            this.BooksOnOrderList.GridLines = true;
            this.BooksOnOrderList.HideSelection = false;
            this.BooksOnOrderList.Location = new System.Drawing.Point(180, 96);
            this.BooksOnOrderList.Name = "BooksOnOrderList";
            this.BooksOnOrderList.Size = new System.Drawing.Size(462, 321);
            this.BooksOnOrderList.TabIndex = 3;
            this.BooksOnOrderList.UseCompatibleStateImageBehavior = false;
            this.BooksOnOrderList.View = System.Windows.Forms.View.Details;
            // 
            // TitleID
            // 
            this.TitleID.Text = "Title ID";
            this.TitleID.Width = 46;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            // 
            // PaymentTermsLabel
            // 
            this.PaymentTermsLabel.AutoSize = true;
            this.PaymentTermsLabel.Location = new System.Drawing.Point(177, 57);
            this.PaymentTermsLabel.Name = "PaymentTermsLabel";
            this.PaymentTermsLabel.Size = new System.Drawing.Size(80, 13);
            this.PaymentTermsLabel.TabIndex = 4;
            this.PaymentTermsLabel.Text = "Payment Terms";
            // 
            // PaymentTermsTextBox
            // 
            this.PaymentTermsTextBox.Location = new System.Drawing.Point(263, 57);
            this.PaymentTermsTextBox.Name = "PaymentTermsTextBox";
            this.PaymentTermsTextBox.ReadOnly = true;
            this.PaymentTermsTextBox.Size = new System.Drawing.Size(379, 20);
            this.PaymentTermsTextBox.TabIndex = 5;
            // 
            // BooksOnOrderLabel
            // 
            this.BooksOnOrderLabel.AutoSize = true;
            this.BooksOnOrderLabel.Location = new System.Drawing.Point(177, 80);
            this.BooksOnOrderLabel.Name = "BooksOnOrderLabel";
            this.BooksOnOrderLabel.Size = new System.Drawing.Size(96, 13);
            this.BooksOnOrderLabel.TabIndex = 6;
            this.BooksOnOrderLabel.Text = "Books On Order #:";
            // 
            // removeOrderToolStripMenuItem
            // 
            this.removeOrderToolStripMenuItem.Name = "removeOrderToolStripMenuItem";
            this.removeOrderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeOrderToolStripMenuItem.Text = "Remove Order";
            this.removeOrderToolStripMenuItem.Click += new System.EventHandler(this.removeOrderToolStripMenuItem_Click);
            // 
            // Book_Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 429);
            this.Controls.Add(this.BooksOnOrderLabel);
            this.Controls.Add(this.PaymentTermsTextBox);
            this.Controls.Add(this.PaymentTermsLabel);
            this.Controls.Add(this.BooksOnOrderList);
            this.Controls.Add(this.StoresDropDown);
            this.Controls.Add(this.OrderIDList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Book_Overview";
            this.Text = "Book Orders";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem placeNewOrderToolStripMenuItem;
        private System.Windows.Forms.ComboBox StoresDropDown;
        private System.Windows.Forms.ListView BooksOnOrderList;
        private System.Windows.Forms.ColumnHeader OrderID;
        private System.Windows.Forms.Label PaymentTermsLabel;
        private System.Windows.Forms.TextBox PaymentTermsTextBox;
        private System.Windows.Forms.Label BooksOnOrderLabel;
        private System.Windows.Forms.ColumnHeader TitleID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Quantity;
        protected internal System.Windows.Forms.ListView OrderIDList;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placeNewOrderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeOrderToolStripMenuItem;
    }
}