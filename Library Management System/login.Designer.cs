namespace Library_Management_System
{
    partial class login
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
            this.label1 = new System.Windows.Forms.Label();
            this.usme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "Library Management System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // usme
            // 
            this.usme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usme.Location = new System.Drawing.Point(460, 165);
            this.usme.Name = "usme";
            this.usme.Size = new System.Drawing.Size(256, 26);
            this.usme.TabIndex = 1;
            this.usme.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(270, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 43);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // pwd
            // 
            this.pwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pwd.Location = new System.Drawing.Point(460, 243);
            this.pwd.MaximumSize = new System.Drawing.Size(500, 600);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(256, 26);
            this.pwd.TabIndex = 4;
            this.pwd.UseSystemPasswordChar = true;
            this.pwd.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Chartreuse;
            this.btn1.Location = new System.Drawing.Point(492, 323);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(134, 58);
            this.btn1.TabIndex = 5;
            this.btn1.Text = "Login";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(44, 27);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(119, 60);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(983, 424);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usme);
            this.Controls.Add(this.label1);
            this.Name = "login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnBack;
    }
}

