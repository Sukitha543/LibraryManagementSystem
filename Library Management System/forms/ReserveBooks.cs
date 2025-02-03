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
    public partial class ReserveBooks : Form
    {
         ReservationManager reservationController = new ReservationManager();
         DataTable borrowingTable;

        public ReserveBooks()
        {
            InitializeComponent();
            LoadBorrowingRecords();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Load borrowing records into the DataGridView
        private void LoadBorrowingRecords()
        {
            borrowingTable = reservationController.GetBorrowingRecords();
            dgvBorrowings.DataSource = borrowingTable;

            // Adjust DataGridView column headers
            dgvBorrowings.Columns["Id"].Visible = false;
            dgvBorrowings.Columns["BookTitle"].HeaderText = "Book Title";
            dgvBorrowings.Columns["BorrowDate"].HeaderText = "Borrow Date";
            dgvBorrowings.Columns["ReturnDate"].HeaderText = "Return Date";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            CustomerMenu Select = new CustomerMenu();
            Select.Show();


            // Hide the ManageBooks form
            this.Hide();
        }

        private void ReserveBooks_Load(object sender, EventArgs e)
        {
            dgvBorrowings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (dgvBorrowings.SelectedRows.Count > 0)
            {
                string customerName = txtName.Text.Trim();
                if (string.IsNullOrEmpty(customerName))
                {
                    MessageBox.Show("Please enter your name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the selected book details
                DataGridViewRow selectedRow = dgvBorrowings.SelectedRows[0];
                string bookTitle = selectedRow.Cells["BookTitle"].Value.ToString();
                DateTime reservationDate = DateTime.Now;

                // Create a reservation object
                Reservation reservation = new Reservation(customerName, bookTitle, reservationDate);

                // Save the reservation
                reservationController.SaveReservation(reservation);

                MessageBox.Show("Reservation made successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
            }
            else
            {
                MessageBox.Show("Please select a book to reserve.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

