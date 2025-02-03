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
    public partial class ManageReservations : Form
    {
        ReservationManager reservationController = new ReservationManager();
        public ManageReservations()
        {
            InitializeComponent();
            LoadReservations();
        }

        private void LoadReservations()
        {
            DataTable reservationsTable = reservationController.GetReservations();
            dgvReservations.DataSource = reservationsTable;

            // Optionally hide the 'Id' column and format the DataGridView
            dgvReservations.Columns["Id"].Visible = false;
            dgvReservations.Columns["CustomerName"].HeaderText = "Customer Name";
            dgvReservations.Columns["BookTitle"].HeaderText = "Book Title";
            dgvReservations.Columns["ReservationDate"].HeaderText = "Reservation Date";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu mainform = new Menu();
            mainform.Show();



            this.Hide();
        }

        private void ManageReservations_Load(object sender, EventArgs e)
        {
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                // Get the ID of the selected reservation
                int reservationId = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["Id"].Value);

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this reservation?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Call the method to delete the reservation from the database
                    reservationController.DeleteReservation(reservationId);

                    // Reload the reservations after deletion
                    LoadReservations();

                    MessageBox.Show("Reservation deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
