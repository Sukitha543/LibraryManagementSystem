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
    public partial class Managebooks : Form
    {
        private BookManager bookControl = new BookManager();

        public Managebooks()
        {
            InitializeComponent();
            LoadBooks();
            
        }

        private void Managebooks_Load(object sender, EventArgs e)
        {

        }

        private void ClearTextFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtGenre.Clear();
            txtISBN.Clear();
        }

        // Load books into the DataGridView
        private void LoadBooks()
        {
            var books = bookControl.GetAllBooks();
            dgvBooks.DataSource = books; // Bind list to DataGridView
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ClearSelection();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if any textboxes are empty
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtGenre.Text) ||
                string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Please fill in all fields (Title, Author, Genre, ISBN).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if any field is empty
            }

            // Check if ISBN already exists
            if (bookControl.IsISBNExist(txtISBN.Text))
            {
                MessageBox.Show("A book with this ISBN already exists.", "ISBN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if ISBN exists
            }

            // Create a new book object and add it to the database
            var book = new Book(0, txtTitle.Text, txtAuthor.Text, txtGenre.Text, txtISBN.Text);
            bookControl.AddBook(book);

            // Refresh the DataGridView to show the newly added book
            LoadBooks();
            ClearTextFields(); // Clear the text fields
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedBook = (Book)dgvBooks.SelectedRows[0].DataBoundItem;

                // Update the book object with the new values from textboxes
                selectedBook.Title = txtTitle.Text;
                selectedBook.Author = txtAuthor.Text;
                selectedBook.Genre = txtGenre.Text;
                selectedBook.ISBN = txtISBN.Text;

                // Refresh the DataGridView and clear text fields
                LoadBooks();
                ClearTextFields();
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
           
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedBook = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
                bookControl.DeleteBook(selectedBook.Id);

                // Refresh the DataGridView after deletion
                LoadBooks();
                ClearTextFields(); // Clear text fields after deletion
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedBook = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
                txtTitle.Text = selectedBook.Title;
                txtAuthor.Text = selectedBook.Author;
                txtGenre.Text = selectedBook.Genre;
                txtISBN.Text = selectedBook.ISBN;
            }
        }

       


        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu mainform = new Menu();
            mainform.Show();


            // Hide the ManageBooks form
            this.Hide();
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }
    }
    
}
