using System;
using System.Collections.Generic;
using System.Data;
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
        public bool insertUser(int userid, string username, string password, string role)
        {
            // Fix: Ensure that @role is declared only once in the SQL query
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserID, Username, Password, Role) VALUES (@UserID, @Username, @Password, @Role)", mydb.getConnection);

            // Ensure parameters are correctly added
            cmd.Parameters.AddWithValue("@UserID", userid);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Role", role);

            mydb.openConnection();
            int result = cmd.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0; // Returns true if insertion was successful
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
        public DataTable getUserByUsername(string username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username = @user", mydb.getConnection);
            command.Parameters.AddWithValue("@user", username);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public bool checkIdNotExist(int userId)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserID = @id", mydb.getConnection);
            command.Parameters.AddWithValue("@id", userId);

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count == 0; // Trả về true nếu ID chưa tồn tại
        }


    }
}
