using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class BookManager
    {
            private string connectionString = "server=localhost;database=LibraryDB;uid=root;pwd=;";

            // Get all books from the database
            public List<Book> GetAllBooks()
            {
                var books = new List<Book>();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Books";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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

            // Add a new book to the database
            public void AddBook(Book book)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO Books (Title, Genre, Author, ISBN) VALUES (@Title, @Genre, @Author, @ISBN)";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Title", book.Title);
                            command.Parameters.AddWithValue("@Genre", book.Genre);
                            command.Parameters.AddWithValue("@Author", book.Author);
                            command.Parameters.AddWithValue("@ISBN", book.ISBN);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while adding book: " + ex.Message);
                }
            }

            // Update an existing book in the database
            public void UpdateBook(Book book)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Books SET Title = @Title, Genre = @Genre, Author = @Author, ISBN = @ISBN WHERE Id = @Id";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", book.Id);
                            command.Parameters.AddWithValue("@Title", book.Title);
                            command.Parameters.AddWithValue("@Genre", book.Genre);
                            command.Parameters.AddWithValue("@Author", book.Author);
                            command.Parameters.AddWithValue("@ISBN", book.ISBN);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while updating book: " + ex.Message);
                }
            }

            // Delete a book from the database
            public void DeleteBook(int bookId)
            {
                try
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Books WHERE Id = @Id";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", bookId);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while deleting book: " + ex.Message);
                }
            }
        }
}