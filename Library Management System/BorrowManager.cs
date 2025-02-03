using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class BorrowManager
    {
        string connectionString = "Server=localhost;Database=libraryDB;Uid=root;Pwd=;";

        // Method to get all book titles
        public List<string> GetBookTitles()
        {
            List<string> bookTitles = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Title FROM Books";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookTitles.Add(reader.GetString("Title"));
                    }
                }
            }
            return bookTitles;
        }

        // Method to save borrowing details
        public void SaveBorrowing(Borrow borrow)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO BorrowedBooks (CustomerName, BookTitle, BorrowDate, ReturnDate) VALUES (@CustomerName, @BookTitle, @BorrowDate, @ReturnDate)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", borrow.CustomerName);
                    cmd.Parameters.AddWithValue("@BookTitle", borrow.BookTitle);
                    cmd.Parameters.AddWithValue("@BorrowDate", borrow.BorrowDate);
                    cmd.Parameters.AddWithValue("@ReturnDate", borrow.ReturnDate.HasValue ? borrow.ReturnDate.Value : (object)DBNull.Value); // Handle nullable returnDate
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Retrieve all borrowings
        public DataTable GetAllBorrowings()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, CustomerName, BookTitle, BorrowDate, ReturnDate FROM BorrowedBooks";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable borrowingsTable = new DataTable();
                    adapter.Fill(borrowingsTable);
                    return borrowingsTable;
                }
            }
        }

        // Method to check if the book is already borrowed
        public bool IsBookBorrowed(string bookTitle)
        {
            bool isBorrowed = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM BorrowedBooks WHERE BookTitle = @BookTitle";
                // Checking if the book title exists in the BorrowedBooks table, regardless of ReturnDate
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        isBorrowed = true; // Book is already borrowed
                    }
                }
            }

            return isBorrowed;
        }


        // Update borrowing record
        public void UpdateBorrowing(int id,DateTime? returnDate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE BorrowedBooks SET ReturnDate = @ReturnDate WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReturnDate", returnDate.HasValue ? returnDate.Value : (object)DBNull.Value);  // Handle nullable returnDate
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Delete borrowing record
        public void DeleteBorrowing(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM BorrowedBooks WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
    



    
}


