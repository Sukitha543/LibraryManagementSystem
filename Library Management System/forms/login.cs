using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class login : Form
    {
         UserManager usercontroller = new UserManager();
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            string username = usme.Text;
            string password = pwd.Text;

            if (usercontroller.UserAuth(username, password))
            {

                // Open the main library management form
                Menu mainform = new Menu();
                mainform.Show();
               

                // Hide the login form
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserMode UserSelection = new UserMode();
            UserSelection.Show();

            this.Hide();
        }
    }
}
