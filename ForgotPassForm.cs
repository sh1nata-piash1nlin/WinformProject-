using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace L2_LoginForm
{
    public partial class ForgotPassForm : Form
    {
        MY_DB myDB = new MY_DB();
        private string otpCode;

        public ForgotPassForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Navigate back to Login Form
        }

        // Generate a random 6-digit OTP
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // Hash the password using SHA256
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

        // Send OTP to the provided email
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
                mail.Subject = "Password Reset OTP";
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

        // Verify OTP and reset password
        private void verifyButton_Click(object sender, EventArgs e)
        {
            string enteredCode = codeTxtBox.Text.Trim();
            string newPassword = newPassTxtBox.Text.Trim();
            string rePassword = rePassTxtBox.Text.Trim();
            string userEmail = emailTxtBox.Text.Trim();

            if (enteredCode != otpCode)
            {
                MessageBox.Show("Invalid OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != rePassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string hashedPassword = HashPassword(newPassword);

                myDB.openConnection();
                SqlCommand cmd = new SqlCommand("UPDATE login SET password = @password WHERE email = @email", myDB.getConnection);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@email", userEmail);

                int rowsAffected = cmd.ExecuteNonQuery();
                myDB.closeConnection();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No account found with this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
