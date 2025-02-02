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
    public partial class BorrowBooks : Form
    {
        public BorrowBooks()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerMenu customermenu = new CustomerMenu();
            customermenu.Show();


            // Hide the ManageBooks form
            this.Hide();
        }
    }
}
