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

namespace L2_LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../images/waifu.jfif");
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text.Trim();
            string password = TextBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            USER user = new USER();
            if (user.VerifyLogin(username, password))
            {
                //MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool VerifyLogin(string username, string password)
        {
            MY_DB db = new MY_DB();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM login WHERE username = @user AND password = @pass", db.getConnection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;

            db.openConnection();
            int count = (int)command.ExecuteScalar();
            db.closeConnection();

            return count > 0; // If count > 0, login is successful
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text.Trim();
            string password = TextBoxPassword.Text.Trim();

            // Check if fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both a username and a password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            USER user = new USER();
            if (user.AddUser(username, password))
            {
                MessageBox.Show("New user added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void registerAccButton_Click(object sender, EventArgs e)
        {
            MailServiceRegister createAccountForm = new MailServiceRegister();
            createAccountForm.Show();
            
        }

        private void forgotPassButton_Click(object sender, EventArgs e)
        {
            ForgotPassForm createPassword = new ForgotPassForm(); 
            createPassword.Show();
        }
    }
}
