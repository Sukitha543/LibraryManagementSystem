using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide current form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide current form
            Register registerForm = new Register();
            registerForm.Show();
        }
    }
}
