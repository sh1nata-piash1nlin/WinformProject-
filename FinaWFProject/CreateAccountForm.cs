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

namespace FinaWFProject
{
    public partial class CreateAccountForm : Form
    {
        int time = 60;
        string randomCode;
        public static string to;
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void sendcodeButton_Click(object sender, EventArgs e)
        {
            string to = emailTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email của bạn", "Gửi mã xác nhận",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email hệ thống gửi mã xác nhận
            string from = "tri14102004@gmail.com";
            string pass = "pozk brni qezo qpoo";

            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng cấu hình email hệ thống hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Random rand = new Random();
                randomCode = rand.Next(100000, 999999).ToString();
                string messageBody = "Mã xác nhận của bạn: " + randomCode;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.To.Add(to);
                message.Subject = "Mã xác nhận đăng ký tài khoản";
                message.Body = messageBody;
                message.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);

                MessageBox.Show("Mã xác nhận đã được gửi thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                sendcodeTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            USER user = new USER();
            int userid = Convert.ToInt32(idTextBox.Text);
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            if (!int.TryParse(idTextBox.Text.Trim(), out userid))
            {
                MessageBox.Show("ID phải là số nguyên hợp lệ", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!checkIdExist(userid))
            {
                MessageBox.Show("ID này đã tồn tại", "Đăng ký user",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (username.Length > 10 || password.Length > 10)
            {
                MessageBox.Show("Username và Password tối đa 10 ký tự!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkInfo() == false)
            {
                MessageBox.Show("Vui lòng không để trống thông tin", "Đăng ký user",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkCode() == false)
            {
                return;
            }

            if (checkUsernameExist(username) == false)
            {
                MessageBox.Show("Username này đã tồn tại", "Đăng ký user",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.insertUser(userid, username, password))
            {
                MessageBox.Show("User đăng ký thành công!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form sau khi đăng ký thành công
                idTextBox.Text = "";
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
                emailTextBox.Text = "";
                codeTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Lỗi khi đăng ký user.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DateTime codeSentTime;

        private bool checkCode()
        {
            if (string.IsNullOrEmpty(randomCode))
            {
                MessageBox.Show("Bạn chưa gửi mã xác nhận", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if ((DateTime.Now - codeSentTime).TotalMinutes > 500)
            //{
            //    MessageBox.Show("Mã xác nhận đã hết hạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            if (codeTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã xác nhận", "Xác nhận mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (randomCode == codeTextBox.Text.Trim())
            {
                to = emailTextBox.Text.Trim();
                return true;
            }
            else
            {
                MessageBox.Show("Mã xác nhận không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool checkUsernameExist(string username)
        {
            USER user = new USER();
            DataTable dt = user.getUserByUsername(username);

            if (dt.Rows.Count > 0)
            {
                return false; // username đã tồn tại
            }

            return true; // username chưa tồn tại
        }
        private void timerSendCode_Tick(object sender, EventArgs e)
        {
            if (time >= 0)
            {
                sendcodeButton.Enabled = false;
                noticeLabel.Text = "Gửi lại mã sau " + time + " giây";
                time--;
            }
            else
            {
                noticeLabel.Text = "";
                time = 60;
                sendcodeButton.Enabled = true;
                sendcodeTimer.Enabled = false;
            }
        }
        private bool checkIdExist(int userid)
        {
            USER user = new USER();
            return user.checkIdNotExist(userid);


        }
        private bool checkInfo()
        {
            if (idTextBox.Text.Trim() == "" ||
                usernameTextBox.Text.Trim() == "" ||
                passwordTextBox.Text.Trim() == "" ||
                emailTextBox.Text.Trim() == "" ||
                codeTextBox.Text.Trim() == "")
                return false;
            return true;
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {

        }
    }
}
