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
    public partial class ManageBorrowings : Form
    {
         BorrowManager borrowbook = new BorrowManager();

        public ManageBorrowings()
        {
            InitializeComponent();
            LoadBorrowings();
        }

        private void LoadBorrowings()
        {
            dgvborrowings.DataSource = borrowbook.GetAllBorrowings();
            dgvborrowings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            

        }

        private void ManageBorrowings_Load(object sender, EventArgs e)
        {
            dgvborrowings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvborrowings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvborrowings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvborrowings.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvborrowings.SelectedRows[0];
               
                 DateTime returnDate = Convert.ToDateTime(selectedRow.Cells["ReturnDate"].Value);
            }

        }
        

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgvborrowings.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvborrowings.SelectedRows[0].Cells["Id"].Value);
                

                // Borrow date is from the selected row (unchanged)
                DateTime borrowDate = Convert.ToDateTime(dgvborrowings.SelectedRows[0].Cells["BorrowDate"].Value);

                // Return date from the DateTimePicker control
                DateTime? returnDate = returnDatePicker.Value != DateTime.Now ? returnDatePicker.Value : (DateTime?)null;

                // Update borrowing record to update return date
                borrowbook.UpdateBorrowing(id, returnDate);

                MessageBox.Show(" updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBorrowings();
            }
            else
            {
                MessageBox.Show("Please select a borrowing record to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvborrowings.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvborrowings.SelectedRows[0].Cells["Id"].Value);

                // Confirm deletion
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this borrowing?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    borrowbook.DeleteBorrowing(id);
                    MessageBox.Show("Borrowing deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBorrowings();
                }
            }
            else
            {
                MessageBox.Show("Please select a borrowing record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
