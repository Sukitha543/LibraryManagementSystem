using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class MemberManager
    {
        string connectionString = "Server=localhost;Database=libraryDB;Uid=root;Pwd=;";

        // Method to retrieve all members
        public List<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Members";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new Member(
                            reader.GetInt32("Id"),
                            reader.GetString("Name"),
                            reader.GetString("Address"),
                            reader.GetString("Telephone"),
                            reader.GetString("Password")
                        ));
                    }
                }
            }
            return members;
        }

        // Method to add a new member
        public void AddMember(Member member)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Members (Name, Address, Telephone, Password) VALUES (@Name, @Address, @Telephone, @Password)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", member.Name);
                    command.Parameters.AddWithValue("@Address", member.Address);
                    command.Parameters.AddWithValue("@Telephone", member.Telephone);
                    command.Parameters.AddWithValue("@Password", member.Password);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to update a member
        public void UpdateMember(Member member)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Members SET Name = @Name, Address = @Address, Telephone = @Telephone, Password = @Password WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", member.Id);
                    command.Parameters.AddWithValue("@Name", member.Name);
                    command.Parameters.AddWithValue("@Address", member.Address);
                    command.Parameters.AddWithValue("@Telephone", member.Telephone);
                    command.Parameters.AddWithValue("@Password", member.Password);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a member
        public void DeleteMember(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Members WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}