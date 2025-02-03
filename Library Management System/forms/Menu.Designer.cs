namespace Library_Management_System
{
    partial class Menu
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
            this.bookbtn = new System.Windows.Forms.Button();
            this.memberbtn = new System.Windows.Forms.Button();
            this.borrowbtn = new System.Windows.Forms.Button();
            this.reservebtn = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookbtn
            // 
            this.bookbtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bookbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookbtn.Location = new System.Drawing.Point(443, 109);
            this.bookbtn.Name = "bookbtn";
            this.bookbtn.Size = new System.Drawing.Size(252, 119);
            this.bookbtn.TabIndex = 0;
            this.bookbtn.Text = "Manage Books";
            this.bookbtn.UseVisualStyleBackColor = false;
            this.bookbtn.Click += new System.EventHandler(this.bookbtn_Click);
            // 
            // memberbtn
            // 
            this.memberbtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.memberbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberbtn.Location = new System.Drawing.Point(132, 109);
            this.memberbtn.Name = "memberbtn";
            this.memberbtn.Size = new System.Drawing.Size(252, 119);
            this.memberbtn.TabIndex = 1;
            this.memberbtn.Text = "Manage Members";
            this.memberbtn.UseVisualStyleBackColor = false;
            this.memberbtn.Click += new System.EventHandler(this.memberbtn_Click);
            // 
            // borrowbtn
            // 
            this.borrowbtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.borrowbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrowbtn.Location = new System.Drawing.Point(132, 259);
            this.borrowbtn.Name = "borrowbtn";
            this.borrowbtn.Size = new System.Drawing.Size(252, 119);
            this.borrowbtn.TabIndex = 2;
            this.borrowbtn.Text = "Manage Borrowings";
            this.borrowbtn.UseVisualStyleBackColor = false;
            this.borrowbtn.Click += new System.EventHandler(this.borrowbtn_Click);
            // 
            // reservebtn
            // 
            this.reservebtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.reservebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservebtn.Location = new System.Drawing.Point(443, 259);
            this.reservebtn.Name = "reservebtn";
            this.reservebtn.Size = new System.Drawing.Size(252, 119);
            this.reservebtn.TabIndex = 3;
            this.reservebtn.Text = "Manage Reservations";
            this.reservebtn.UseVisualStyleBackColor = false;
            this.reservebtn.Click += new System.EventHandler(this.reservebtn_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(23, 29);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(86, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.reservebtn);
            this.Controls.Add(this.borrowbtn);
            this.Controls.Add(this.memberbtn);
            this.Controls.Add(this.bookbtn);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bookbtn;
        private System.Windows.Forms.Button memberbtn;
        private System.Windows.Forms.Button borrowbtn;
        private System.Windows.Forms.Button reservebtn;
        private System.Windows.Forms.Button btnLogout;
    }
}