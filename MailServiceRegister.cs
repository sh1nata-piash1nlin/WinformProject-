using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace L2_LoginForm
{
    public partial class MailServiceRegister : Form
    {
        MY_DB myDB = new MY_DB();
        private string otpCode;

        public MailServiceRegister()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) //nevermind to all of this chatGPT
        {

        }

        private void label1_Click(object sender, EventArgs e) //nevermind to all of this chatGPT
        {

        }

        private void label2_Click(object sender, EventArgs e) //nevermind to all of this chatGPT
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //nevermind to all of this chatGPT
        {

        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Generate a random 6-digit OTP
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // Send OTP to user's email
        private void sendCodeButton_Click(object sender, EventArgs e)
        {
            string userEmail = emailTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            otpCode = GenerateOTP();

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("tri14102004@gmail.com"); // Replace with your email
                mail.To.Add(userEmail);
                mail.Subject = "Your OTP Code";
                mail.Body = $"Your OTP code is: {otpCode}";

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("tri14102004@gmail.com", "pozk brni qezo qpoo"); // Replace with your credentials
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                MessageBox.Show("OTP sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Verify the OTP code
        private void okButton_Click(object sender, EventArgs e)
        {
            if (codeTxtBox.Text.Trim() == otpCode)
            {
                MessageBox.Show("OTP Verified Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string username = usernameTxtBox.Text.Trim();
                string password = passwordTxtBox.Text.Trim();
                string email = emailTxtBox.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string hashedPassword = HashPassword(password);

                    myDB.openConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO login (username, password, email) VALUES (@username, @password, @email)", myDB.getConnection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    myDB.closeConnection();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error creating account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
