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
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog before logging out
            DialogResult confirmResult = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Check user's response
            if (confirmResult == DialogResult.Yes)
            {
                // If user confirms, show the login form
                UserMode user = new UserMode();
                user.Show();

                // Close the current form
                this.Close();
            }
            else
            {
                // If user cancels, do nothing
                MessageBox.Show("Logout canceled.", "Action Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            //Open the main library management form
            BorrowBooks borrow = new BorrowBooks();
            borrow.Show();


            // Hide the login form
            this.Hide();
        }
    }
    
}
