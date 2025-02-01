using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class BookManager
    {
        string connectionString = "Server=localhost;Database=libraryDB;Uid=root;Pwd=;";

        // Method to check if a book with the given ISBN already exists
        public bool IsISBNExist(string isbn)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Books WHERE ISBN = @ISBN";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ISBN", isbn);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // Returns true if ISBN already exists
                }
            }
        }


        // Method to retrieve all books
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Books";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Using the constructor to create a new Book object
                        books.Add(new Book(
                            reader.GetInt32("Id"),
                            reader.GetString("Title"),
                            reader.GetString("Author"),
                            reader.GetString("Genre"),
                            reader.GetString("ISBN")
                        ));
                    }
                }
            }
            return books;
        }

        // Method to add a new book
        public void AddBook(Book book)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Books (Title, Author, Genre, ISBN) VALUES (@Title, @Author, @Genre, @ISBN)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to update a book
        public void UpdateBook(Book book)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Books SET Title = @Title, Author = @Author, Genre = @Genre, ISBN = @ISBN WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", book.Id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a book
        public void DeleteBook(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Books WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}

