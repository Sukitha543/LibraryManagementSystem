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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void bookbtn_Click(object sender, EventArgs e)
        {
            //Open the main library management form
            Managebooks manageBooks = new Managebooks();
            manageBooks.Show();


            // Hide the login form
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void memberbtn_Click(object sender, EventArgs e)
        {
            // Open the ManageMember form
            ManageMember manageMember = new ManageMember();
            manageMember.Show();

            // Optionally, hide the current Menu form
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
                UserMode userselect = new UserMode();
                userselect.Show();

                // Close the current form
                this.Close();
            }
            else
            {
                // If user cancels, do nothing
                MessageBox.Show("Logout canceled.", "Action Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void borrowbtn_Click(object sender, EventArgs e)
        {
            
            ManageBorrowings borrowBooks = new ManageBorrowings();
            borrowBooks.Show();

            // Optionally, hide the current Menu form
            this.Hide();
        }

        private void reservebtn_Click(object sender, EventArgs e)
        {
            ManageReservations borrowBooks = new ManageReservations();
            borrowBooks.Show();

            
            this.Hide();
        }
    }
}
