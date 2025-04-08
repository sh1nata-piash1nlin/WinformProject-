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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                usernameTextBox.BackColor = Color.LightCoral;
                usernameErrorLabel.Text = "Vui lòng nhập tên đăng nhập!";
                isValid = false;
            }
            else
            {
                usernameTextBox.BackColor = Color.White;
                usernameErrorLabel.Text = "";
            }

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                passwordTextBox.BackColor = Color.LightCoral;
                passwordErrorLabel.Text = "Vui lòng nhập mật khẩu!";
                isValid = false;
            }
            else
            {
                passwordTextBox.BackColor = Color.White;
                passwordErrorLabel.Text = "";
            }

            if (!isValid) return;

            loginProgressBar.Visible = true;
            loginProgressBar.Minimum = 0;
            loginProgressBar.Maximum = 100;
            loginProgressBar.Value = 0;

            for (int i = 0; i <= 100; i += 5)
            {
                loginProgressBar.Value = i;
                await Task.Delay(50);
            }

            MY_DB db = new MY_DB();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Users WHERE Username = @User AND Password = @Pass", db.getConnection);
            command.Parameters.Add("@User", SqlDbType.NVarChar).Value = usernameTextBox.Text;
            command.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = passwordTextBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            loginProgressBar.Visible = false;

            if (table.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            CreateAccountForm form = new CreateAccountForm(); 
            form.ShowDialog();
        }

        private void forgotpasswordLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendCodeForm form = new SendCodeForm();
            form.ShowDialog();
        }
    }
}
