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
    public partial class UserMode : Form
    {
        public UserMode()
        {
            InitializeComponent();
        }

        private void UserMode_Load(object sender, EventArgs e)
        {

        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            // Open the librarian credentials form
            login librarianlogin = new login();
            librarianlogin.Show();


            //Hide user mode inerface
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            // Open the librarian credentials form
            CustomerLogin Customer = new CustomerLogin();
            Customer.Show();


            //Hide user mode inerface
            this.Hide();
        }
    }
}
