namespace Library_Management_System
{
    partial class CustomerMenu
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
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReserveBook = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(272, 154);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(205, 120);
            this.btnBorrow.TabIndex = 0;
            this.btnBorrow.Text = "Borrow Book";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnReserveBook
            // 
            this.btnReserveBook.Location = new System.Drawing.Point(546, 154);
            this.btnReserveBook.Name = "btnReserveBook";
            this.btnReserveBook.Size = new System.Drawing.Size(198, 120);
            this.btnReserveBook.TabIndex = 1;
            this.btnReserveBook.Text = "Reserve Book";
            this.btnReserveBook.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(45, 25);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(123, 54);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // CustomerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 450);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnReserveBook);
            this.Controls.Add(this.btnBorrow);
            this.Name = "CustomerMenu";
            this.Text = "CustomerMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReserveBook;
        private System.Windows.Forms.Button btnLogOut;
    }
}