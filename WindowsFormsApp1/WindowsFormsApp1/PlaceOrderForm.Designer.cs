namespace WindowsFormsApp1
{
    partial class PlaceOrderForm
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
            this.order_bookstoreTextBox = new System.Windows.Forms.TextBox();
            this.payTermsDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.booksOnOrderLabelPOF = new System.Windows.Forms.Label();
            this.addBooksButton = new System.Windows.Forms.Button();
            this.removeBookButton = new System.Windows.Forms.Button();
            this.bookOrderListViewPOF = new System.Windows.Forms.ListView();
            this.title_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.submitOrderButton = new System.Windows.Forms.Button();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.editBookQuantityButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // order_bookstoreTextBox
            // 
            this.order_bookstoreTextBox.Location = new System.Drawing.Point(6, 6);
            this.order_bookstoreTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.order_bookstoreTextBox.Name = "order_bookstoreTextBox";
            this.order_bookstoreTextBox.ReadOnly = true;
            this.order_bookstoreTextBox.Size = new System.Drawing.Size(444, 20);
            this.order_bookstoreTextBox.TabIndex = 0;
            // 
            // payTermsDropDown
            // 
            this.payTermsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payTermsDropDown.FormattingEnabled = true;
            this.payTermsDropDown.Items.AddRange(new object[] {
            "Net 30",
            "Net 60",
            "ON invoice"});
            this.payTermsDropDown.Location = new System.Drawing.Point(90, 30);
            this.payTermsDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.payTermsDropDown.Name = "payTermsDropDown";
            this.payTermsDropDown.Size = new System.Drawing.Size(115, 21);
            this.payTermsDropDown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Terms";
            // 
            // booksOnOrderLabelPOF
            // 
            this.booksOnOrderLabelPOF.AutoSize = true;
            this.booksOnOrderLabelPOF.Location = new System.Drawing.Point(6, 53);
            this.booksOnOrderLabelPOF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.booksOnOrderLabelPOF.Name = "booksOnOrderLabelPOF";
            this.booksOnOrderLabelPOF.Size = new System.Drawing.Size(86, 13);
            this.booksOnOrderLabelPOF.TabIndex = 3;
            this.booksOnOrderLabelPOF.Text = "Books On Order:";
            // 
            // addBooksButton
            // 
            this.addBooksButton.Location = new System.Drawing.Point(209, 30);
            this.addBooksButton.Margin = new System.Windows.Forms.Padding(2);
            this.addBooksButton.Name = "addBooksButton";
            this.addBooksButton.Size = new System.Drawing.Size(75, 23);
            this.addBooksButton.TabIndex = 4;
            this.addBooksButton.Text = "Add Book";
            this.addBooksButton.UseVisualStyleBackColor = true;
            this.addBooksButton.Click += new System.EventHandler(this.addBooksButton_Click);
            // 
            // removeBookButton
            // 
            this.removeBookButton.Enabled = false;
            this.removeBookButton.Location = new System.Drawing.Point(288, 30);
            this.removeBookButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeBookButton.Name = "removeBookButton";
            this.removeBookButton.Size = new System.Drawing.Size(83, 23);
            this.removeBookButton.TabIndex = 5;
            this.removeBookButton.Text = "Remove Book";
            this.removeBookButton.UseVisualStyleBackColor = true;
            this.removeBookButton.Click += new System.EventHandler(this.removeBookButton_Click);
            // 
            // bookOrderListViewPOF
            // 
            this.bookOrderListViewPOF.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title_id,
            this.title,
            this.qty});
            this.bookOrderListViewPOF.FullRowSelect = true;
            this.bookOrderListViewPOF.GridLines = true;
            this.bookOrderListViewPOF.HideSelection = false;
            this.bookOrderListViewPOF.Location = new System.Drawing.Point(6, 68);
            this.bookOrderListViewPOF.Margin = new System.Windows.Forms.Padding(2);
            this.bookOrderListViewPOF.Name = "bookOrderListViewPOF";
            this.bookOrderListViewPOF.Size = new System.Drawing.Size(444, 348);
            this.bookOrderListViewPOF.TabIndex = 6;
            this.bookOrderListViewPOF.UseCompatibleStateImageBehavior = false;
            this.bookOrderListViewPOF.View = System.Windows.Forms.View.Details;
            this.bookOrderListViewPOF.Click += new System.EventHandler(this.bookOrderListViewPOF_Click);
            // 
            // title_id
            // 
            this.title_id.Text = "Title ID";
            this.title_id.Width = 50;
            // 
            // title
            // 
            this.title.Text = "Title";
            this.title.Width = 50;
            // 
            // qty
            // 
            this.qty.Text = "Quantity";
            this.qty.Width = 50;
            // 
            // submitOrderButton
            // 
            this.submitOrderButton.Enabled = false;
            this.submitOrderButton.Location = new System.Drawing.Point(6, 420);
            this.submitOrderButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitOrderButton.Name = "submitOrderButton";
            this.submitOrderButton.Size = new System.Drawing.Size(80, 23);
            this.submitOrderButton.TabIndex = 7;
            this.submitOrderButton.Text = "Submit Order";
            this.submitOrderButton.UseVisualStyleBackColor = true;
            this.submitOrderButton.Click += new System.EventHandler(this.submitOrderButton_Click);
            // 
            // cancelOrderButton
            // 
            this.cancelOrderButton.Location = new System.Drawing.Point(90, 420);
            this.cancelOrderButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(79, 23);
            this.cancelOrderButton.TabIndex = 8;
            this.cancelOrderButton.Text = "Cancel Order";
            this.cancelOrderButton.UseVisualStyleBackColor = true;
            this.cancelOrderButton.Click += new System.EventHandler(this.cancelOrderButton_Click);
            // 
            // editBookQuantityButton
            // 
            this.editBookQuantityButton.Enabled = false;
            this.editBookQuantityButton.Location = new System.Drawing.Point(375, 30);
            this.editBookQuantityButton.Margin = new System.Windows.Forms.Padding(2);
            this.editBookQuantityButton.Name = "editBookQuantityButton";
            this.editBookQuantityButton.Size = new System.Drawing.Size(75, 23);
            this.editBookQuantityButton.TabIndex = 9;
            this.editBookQuantityButton.Text = "Edit Quantity";
            this.editBookQuantityButton.UseVisualStyleBackColor = true;
            this.editBookQuantityButton.Click += new System.EventHandler(this.editBookQuantityButton_Click);
            // 
            // PlaceOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 446);
            this.Controls.Add(this.editBookQuantityButton);
            this.Controls.Add(this.cancelOrderButton);
            this.Controls.Add(this.submitOrderButton);
            this.Controls.Add(this.bookOrderListViewPOF);
            this.Controls.Add(this.removeBookButton);
            this.Controls.Add(this.addBooksButton);
            this.Controls.Add(this.booksOnOrderLabelPOF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.payTermsDropDown);
            this.Controls.Add(this.order_bookstoreTextBox);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaceOrderForm";
            this.Text = "Place Order Form";
            this.Load += new System.EventHandler(this.PlaceOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox order_bookstoreTextBox;
        private System.Windows.Forms.ComboBox payTermsDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label booksOnOrderLabelPOF;
        private System.Windows.Forms.Button addBooksButton;
        private System.Windows.Forms.Button removeBookButton;
        private System.Windows.Forms.ListView bookOrderListViewPOF;
        private System.Windows.Forms.ColumnHeader title_id;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader qty;
        private System.Windows.Forms.Button submitOrderButton;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.Button editBookQuantityButton;
    }
}