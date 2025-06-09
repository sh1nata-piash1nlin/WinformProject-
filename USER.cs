using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace L2_LoginForm
{
    class USER
    {
        MY_DB mydb = new MY_DB();

        // Hash password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert to hexadecimal format
                }
                return builder.ToString();
            }
        }

        // Add a new user with hashed password
        public bool AddUser(string username, string password)
        {
            string hashedPassword = HashPassword(password); // Hash password

            SqlCommand command = new SqlCommand("INSERT INTO login (username, password) VALUES (@user, @pass)", mydb.getConnection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = hashedPassword;

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        // Verify login with hashed password
        public bool VerifyLogin(string username, string password)
        {
            string hashedPassword = HashPassword(password); // Hash input password

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM login WHERE username = @user AND password = @pass", mydb.getConnection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = hashedPassword;

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0;
        }
    }
}