using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinaWFProject
{
    public partial class ResetPasswordForm : Form
    {
        private string username;
        

        // Constructor mới nhận email
        public ResetPasswordForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string newPass = newpasswordTextBox.Text.Trim();
            string confirmPass = confirmpasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connStr = "Data Source=.;Initial Catalog=TenDatabaseCuaBan;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Lấy mật khẩu cũ
                    string getOldPassQuery = "SELECT Password FROM Users WHERE Username = @Username";
                    string oldPass = "";
                    using (SqlCommand cmd = new SqlCommand(getOldPassQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            oldPass = result.ToString();
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // So sánh mật khẩu mới
                    if (newPass == oldPass)
                    {
                        MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cập nhật mật khẩu
                    string updateQuery = "UPDATE Users SET Password = @Password WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPass);
                        cmd.Parameters.AddWithValue("@Username", username);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Đặt lại mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
