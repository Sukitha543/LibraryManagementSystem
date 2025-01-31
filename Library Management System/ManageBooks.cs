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
    public partial class ManageBooks : Form
    {
        private BookManager bookControl = new BookManager();
        private int selectedBookId = -1;

        public ManageBooks()
        {
            InitializeComponent();
            LoadBooks();
        }

        // Load books into DataGridView
        private void LoadBooks()
        {
            dgvBooks.DataSource = bookControl.GetAllBooks();
        }
        private void ManageBooks_Load(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var book = new Book
                {
                    Title = txtTitle.Text,
                    Genre = txtGenre.Text,
                    Author = txtAuthor.Text,
                    ISBN = txtISBN.Text
                };

                bookControl.AddBook(book);
                LoadBooks(); // Refresh the grid
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Please select a book to edit.");
                return;
            }

            try
            {
                var book = new Book
                {
                    Id = selectedBookId,
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Genre = txtGenre.Text,
                    ISBN = txtISBN.Text
                };

                bookControl.UpdateBook(book);
                LoadBooks(); // Refresh the grid
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Please select a book to delete.");
                return;
            }

            try
            {
                bookControl.DeleteBook(selectedBookId);
                LoadBooks(); // Refresh the grid
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                selectedBookId = Convert.ToInt32(row.Cells["Id"].Value);
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtGenre.Text = row.Cells["Genre"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            txtTitle.Text = "";
            txtGenre.Text = "";
            txtAuthor.Text = "";
            txtISBN.Text = "";
            selectedBookId = -1;
        }
    }
}
