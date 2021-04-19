namespace WindowsFormsApp1
{
    partial class BookQuantityForm
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
            this.bookToEditTextBox = new System.Windows.Forms.TextBox();
            this.editQuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.editQuantityButton = new System.Windows.Forms.Button();
            this.quantityCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editQuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bookToEditTextBox
            // 
            this.bookToEditTextBox.Enabled = false;
            this.bookToEditTextBox.Location = new System.Drawing.Point(11, 11);
            this.bookToEditTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.bookToEditTextBox.Name = "bookToEditTextBox";
            this.bookToEditTextBox.ReadOnly = true;
            this.bookToEditTextBox.Size = new System.Drawing.Size(386, 20);
            this.bookToEditTextBox.TabIndex = 0;
            // 
            // editQuantityUpDown
            // 
            this.editQuantityUpDown.Location = new System.Drawing.Point(11, 36);
            this.editQuantityUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.editQuantityUpDown.Name = "editQuantityUpDown";
            this.editQuantityUpDown.ReadOnly = true;
            this.editQuantityUpDown.Size = new System.Drawing.Size(60, 20);
            this.editQuantityUpDown.TabIndex = 1;
            // 
            // editQuantityButton
            // 
            this.editQuantityButton.Location = new System.Drawing.Point(76, 36);
            this.editQuantityButton.Name = "editQuantityButton";
            this.editQuantityButton.Size = new System.Drawing.Size(75, 23);
            this.editQuantityButton.TabIndex = 2;
            this.editQuantityButton.Text = "Edit Quantity";
            this.editQuantityButton.UseVisualStyleBackColor = true;
            this.editQuantityButton.Click += new System.EventHandler(this.editQuantityButton_Click);
            // 
            // quantityCancelButton
            // 
            this.quantityCancelButton.Location = new System.Drawing.Point(157, 36);
            this.quantityCancelButton.Name = "quantityCancelButton";
            this.quantityCancelButton.Size = new System.Drawing.Size(75, 23);
            this.quantityCancelButton.TabIndex = 3;
            this.quantityCancelButton.Text = "Cancel";
            this.quantityCancelButton.UseVisualStyleBackColor = true;
            this.quantityCancelButton.Click += new System.EventHandler(this.quantityCancelButton_Click);
            // 
            // BookQuantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 67);
            this.Controls.Add(this.quantityCancelButton);
            this.Controls.Add(this.editQuantityButton);
            this.Controls.Add(this.editQuantityUpDown);
            this.Controls.Add(this.bookToEditTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookQuantityForm";
            this.Text = "Edit Book Quantity";
            this.Load += new System.EventHandler(this.BookQuantityForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editQuantityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bookToEditTextBox;
        private System.Windows.Forms.NumericUpDown editQuantityUpDown;
        private System.Windows.Forms.Button editQuantityButton;
        private System.Windows.Forms.Button quantityCancelButton;
    }
}