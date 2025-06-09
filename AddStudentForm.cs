using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2_LoginForm
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            //studentPictureBox.Image = Image.FromFile("../../images/waifu.jfif");
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                studentPictureBox.Image = Image.FromFile(opf.FileName);
            }
        }

        bool verif()
        {
            if ((firstNameTxtBox.Text.Trim() == "")
                || (lastNameTxtBox.Text.Trim() == "")
                || (addressTxtBox.Text.Trim() == "")
                || (phoneTxtBox.Text.Trim() == "")
                || (studentPictureBox.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            STUDENT student = new STUDENT();
            int id = Convert.ToInt32(studentIDTxtBox.Text);
            string fname = firstNameTxtBox.Text;
            string lname = lastNameTxtBox.Text;
            DateTime bdate = birthDateDTP.Value;
            string phone = phoneTxtBox.Text;
            string adrs = addressTxtBox.Text;
            string gender = "Male";

            if (femaleRadioButton.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = birthDateDTP.Value.Year;
            int this_year = DateTime.Now.Year;

            // Student age must be between 3 and 90 years
            if ((this_year - born_year) < 3 || (this_year - born_year) > 90)
            {
                MessageBox.Show("The Student Age Must Be Between 3 and 90 years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Fname and Lname must have no number available  
            else if (!fname.All(char.IsLetter) || !lname.All(char.IsLetter))
            {
                MessageBox.Show("First Name and Last Name must contain only letters.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Phone Number must contain only digits
            else if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must contain only digits.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                studentPictureBox.Image.Save(pic, studentPictureBox.Image.RawFormat);
                if (student.insertStudent(id, fname, lname, bdate, gender, phone, adrs, pic))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void birthDateDTP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void importButton_Click(object sender, EventArgs e)
        {

        }
    }
}
