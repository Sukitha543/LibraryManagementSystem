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
    
    public partial class CustomerLogin : Form
    {
        private UserController userController;
        public CustomerLogin()
        {
            InitializeComponent();
            userController = new UserController(); // Initialize UserController instance

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserMode UserSelection = new UserMode();
            UserSelection.Show();


            // Hide the ManageBooks form
            this.Hide();
        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the password from the password textbox
            string password = pwd.Text;
            string name = username.Text;

            // Validate that the password is not empty
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter the password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Use the UserController to authenticate the customer
            if (userController.CustomerAuth(password,name))
            {
                MessageBox.Show("Login successful! Welcome, Customer.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to the customer dashboard or main form
                CustomerMenu dashboard = new CustomerMenu();
                dashboard.Show();

                // Hide the login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
    
    
}
