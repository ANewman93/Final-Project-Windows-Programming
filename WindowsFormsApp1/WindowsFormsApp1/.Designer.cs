namespace WindowsFormsApp1
{
    partial class BookList
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
            this.booksByTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.publishersList = new System.Windows.Forms.ListView();
            this.bookTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookPublisherId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookPublisherName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bookPublishedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.AddBookButton = new System.Windows.Forms.Button();
            this.bookQuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.quantityToAddLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookQuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // booksByTextBox
            // 
            this.booksByTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.booksByTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.booksByTextBox.Enabled = false;
            this.booksByTextBox.Location = new System.Drawing.Point(572, -98);
            this.booksByTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.booksByTextBox.Name = "booksByTextBox";
            this.booksByTextBox.ReadOnly = true;
            this.booksByTextBox.Size = new System.Drawing.Size(296, 13);
            this.booksByTextBox.TabIndex = 22;
            this.booksByTextBox.Text = "Books by: ";
            // 
            // authorTextBox
            // 
            this.authorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.authorTextBox.Enabled = false;
            this.authorTextBox.Location = new System.Drawing.Point(0, 25);
            this.authorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.ReadOnly = true;
            this.authorTextBox.Size = new System.Drawing.Size(42, 13);
            this.authorTextBox.TabIndex = 23;
            this.authorTextBox.Text = "  Authors";
            // 
            // publishersList
            // 
            this.publishersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bookTitle,
            this.bookType,
            this.bookPublisherId,
            this.bookPublisherName,
            this.bookPrice,
            this.bookPublishedDate});
            this.publishersList.FullRowSelect = true;
            this.publishersList.GridLines = true;
            this.publishersList.HideSelection = false;
            this.publishersList.LabelWrap = false;
            this.publishersList.Location = new System.Drawing.Point(11, 11);
            this.publishersList.Margin = new System.Windows.Forms.Padding(2);
            this.publishersList.MultiSelect = false;
            this.publishersList.Name = "publishersList";
            this.publishersList.Size = new System.Drawing.Size(714, 343);
            this.publishersList.TabIndex = 8;
            this.publishersList.UseCompatibleStateImageBehavior = false;
            this.publishersList.View = System.Windows.Forms.View.Details;
            // 
            // bookTitle
            // 
            this.bookTitle.Text = "Title";
            this.bookTitle.Width = 53;
            // 
            // bookType
            // 
            this.bookType.Text = "Type";
            // 
            // bookPublisherId
            // 
            this.bookPublisherId.Text = "Publisher Id";
            this.bookPublisherId.Width = 125;
            // 
            // bookPublisherName
            // 
            this.bookPublisherName.Text = "Publisher Name";
            this.bookPublisherName.Width = 164;
            // 
            // bookPrice
            // 
            this.bookPrice.Text = "Price";
            this.bookPrice.Width = 61;
            // 
            // bookPublishedDate
            // 
            this.bookPublishedDate.Text = "Published Date";
            this.bookPublishedDate.Width = 158;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.AddBookButton);
            this.panel2.Controls.Add(this.bookQuantityUpDown);
            this.panel2.Controls.Add(this.quantityToAddLabel);
            this.panel2.Controls.Add(this.publishersList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 390);
            this.panel2.TabIndex = 25;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(256, 358);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddBookButton
            // 
            this.AddBookButton.Location = new System.Drawing.Point(177, 358);
            this.AddBookButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddBookButton.Name = "AddBookButton";
            this.AddBookButton.Size = new System.Drawing.Size(75, 23);
            this.AddBookButton.TabIndex = 12;
            this.AddBookButton.Text = "Add Book";
            this.AddBookButton.UseVisualStyleBackColor = true;
            this.AddBookButton.Click += new System.EventHandler(this.AddBookButton_Click);
            // 
            // bookQuantityUpDown
            // 
            this.bookQuantityUpDown.Location = new System.Drawing.Point(98, 358);
            this.bookQuantityUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.bookQuantityUpDown.Name = "bookQuantityUpDown";
            this.bookQuantityUpDown.ReadOnly = true;
            this.bookQuantityUpDown.Size = new System.Drawing.Size(75, 20);
            this.bookQuantityUpDown.TabIndex = 11;
            // 
            // quantityToAddLabel
            // 
            this.quantityToAddLabel.AutoSize = true;
            this.quantityToAddLabel.Location = new System.Drawing.Point(11, 360);
            this.quantityToAddLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quantityToAddLabel.Name = "quantityToAddLabel";
            this.quantityToAddLabel.Size = new System.Drawing.Size(83, 13);
            this.quantityToAddLabel.TabIndex = 9;
            this.quantityToAddLabel.Text = "Quantity to Add:";
            // 
            // BookList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 390);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.booksByTextBox);
            this.Controls.Add(this.authorTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BookList";
            this.Text = "Add Books to Order";
            this.Load += new System.EventHandler(this.BookList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookQuantityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox booksByTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        public System.Windows.Forms.ListView publishersList;
        private System.Windows.Forms.ColumnHeader bookTitle;
        private System.Windows.Forms.ColumnHeader bookType;
        private System.Windows.Forms.ColumnHeader bookPublisherId;
        private System.Windows.Forms.ColumnHeader bookPublisherName;
        private System.Windows.Forms.ColumnHeader bookPrice;
        private System.Windows.Forms.ColumnHeader bookPublishedDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label quantityToAddLabel;
        private System.Windows.Forms.NumericUpDown bookQuantityUpDown;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button AddBookButton;
    }
}

