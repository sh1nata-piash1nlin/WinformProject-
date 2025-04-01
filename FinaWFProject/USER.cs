using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinaWFProject
{
    internal class USER
    {
        MY_DB mydb = new MY_DB();

        // Function to hash passwords using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Function to add a new user
        public bool AddUser(string username, string password, string role)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@user, @pass, @role)", mydb.getConnection);
            command.Parameters.Add("@user", System.Data.SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = HashPassword(password);
            command.Parameters.Add("@role", System.Data.SqlDbType.NVarChar).Value = role;

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0; // Return true if insert successful
        }

        // Function to check login credentials
        public string Login(string username, string password)
        {
            SqlCommand command = new SqlCommand("SELECT Role FROM Users WHERE Username = @user AND Password = @pass", mydb.getConnection);
            command.Parameters.Add("@user", System.Data.SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = HashPassword(password);

            mydb.openConnection();
            object result = command.ExecuteScalar();
            mydb.closeConnection();

            return result != null ? result.ToString() : null; // Returns role if valid login, else null
        }
    }
}
