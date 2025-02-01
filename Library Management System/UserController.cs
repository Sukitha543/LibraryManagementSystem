using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Library_Management_System
{
    public class UserController
   
    {
        string connectionString = "Server=localhost;Database=libraryDB;Uid=root;Pwd=;";
        public bool UserAuth(string username, string password)
        {
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                using (var command = new MySqlCommand(query, conn))
                {
                   command.Parameters.AddWithValue("@Username", username);
                   command.Parameters.AddWithValue("@password", password);

                    int userCount = Convert.ToInt32(command.ExecuteScalar());
                    return userCount > 0;
                }
            }
        }

          // Method for customer authentication (username is fixed as "customer")
        public bool CustomerAuth(string password, string name)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Members WHERE Name = @Name AND Password = @Password";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Name", name);



                    int userCount = Convert.ToInt32(command.ExecuteScalar());
                    return userCount > 0;
                }
            }
        }
    }
}
