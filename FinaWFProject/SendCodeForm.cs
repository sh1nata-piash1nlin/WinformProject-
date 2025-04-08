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
    public partial class SendCodeForm : Form
    {
        int time = 60;
        string randomCode;
        public static string to;
        public SendCodeForm()
        {
            InitializeComponent();
        }

        private void backLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
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
            string from = "baocongthu@gmail.com";
            string pass = "psenbkvgjksjyoyc";

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

        private void verifyButton_Click(object sender, EventArgs e)
        {
            if (checkCode())
            {
                MessageBox.Show("Xác minh mã thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bạn có thể đóng form hoặc mở form tạo tài khoản tại đây
                this.DialogResult = DialogResult.OK; // hoặc

                // Lưu email đã xác minh nếu cần dùng lại
                to = emailTextBox.Text.Trim();

                // Mở form đặt lại mật khẩu
                ResetPasswordForm resetForm = new ResetPasswordForm(to);
                resetForm.Show();
                this.Hide();
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

            if ((DateTime.Now - codeSentTime).TotalMinutes > 5)
            {
                MessageBox.Show("Mã xác nhận đã hết hạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

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
    }
}
