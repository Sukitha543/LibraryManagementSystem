using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class ReservationManager
    {
        string connectionString = "Server=localhost;Database=libraryDB;Uid=root;Pwd=;";

        // Retrieve borrowings
        public DataTable GetBorrowingRecords()
        {
            DataTable borrowingsTable = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, BookTitle, BorrowDate, ReturnDate FROM BorrowedBooks";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(borrowingsTable);
                    }
                }
            }

            return borrowingsTable;
        }

        // Save a reservation
        public void SaveReservation(Reservation reservation)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Reservations (CustomerName, BookTitle, ReservationDate) VALUES (@CustomerName, @BookTitle, @ReservationDate)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", reservation.CustomerName);
                    cmd.Parameters.AddWithValue("@BookTitle", reservation.BookTitle);
                    cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to retrieve all reservations from the database
        public DataTable GetReservations()
        {
            DataTable reservationsTable = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, CustomerName, BookTitle, ReservationDate FROM Reservations";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(reservationsTable);
                    }
                }
            }
            return reservationsTable;
        }

        // Delete a reservation by ID
        public void DeleteReservation(int reservationId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Reservations WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", reservationId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}



