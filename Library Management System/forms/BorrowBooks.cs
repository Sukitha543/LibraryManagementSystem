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
         BorrowManager borrowController = new BorrowManager();


        public BorrowBooks()
        {
            InitializeComponent();
            LoadBookTitles();
        }

        private void LoadBookTitles()
        {
            List<string> bookTitles = borrowController.GetBookTitles();
            cmbBookTitles.DataSource = bookTitles;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerMenu Select = new CustomerMenu();
            Select.Show();


            
            this.Hide();
        }

        private void BorrowBooks_Load(object sender, EventArgs e)
        {

        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string selectedBook = cmbBookTitles.SelectedItem?.ToString();

           
            if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(selectedBook))
            {
                MessageBox.Show("Please enter your name and select a book.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the book has already been borrowed
            bool isBookBorrowed = borrowController.IsBookBorrowed(selectedBook);

            if (isBookBorrowed)
            {
                MessageBox.Show("The selected book has already been borrowed. Please choose a different book.", "Book Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Default return date 
            DateTime returnDate = DateTime.Now.AddDays(14);

            // Save borrowing details
            Borrow borrowDetails = new Borrow(customerName, selectedBook, DateTime.Now, returnDate);
            borrowController.SaveBorrowing(borrowDetails);

            MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear inputs
            txtCustomerName.Clear();
            cmbBookTitles.SelectedIndex = -1;
        }
    }
    
}
    

    

