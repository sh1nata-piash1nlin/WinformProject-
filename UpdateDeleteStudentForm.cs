using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace L2_LoginForm
{
    public partial class UpdateDeleteStudentForm : Form
    {
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idTxtBox.Text);
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std WHERE id = " + id);

            DataTable table = student.getStudents(command);

            if (table.Rows.Count > 0)
            {
                firstNameTxtBox.Text = table.Rows[0]["fname"].ToString();
                lastNameTxtBox.Text = table.Rows[0]["lname"].ToString();
                dobDateTimePicker.Value = (DateTime)table.Rows[0]["bdate"];

                // gender
                if (table.Rows[0]["gender"].ToString().Trim() == "Female")
                {
                    femaleRadioButton.Checked = true;
                }
                else
                {
                    maleRadioButton.Checked = true;
                }

                phoneNumberTxtBox.Text = table.Rows[0]["phone"].ToString();
                addressTxtBox.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                imagePictureBox.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(idTxtBox.Text) ||
                    string.IsNullOrWhiteSpace(firstNameTxtBox.Text) ||
                    string.IsNullOrWhiteSpace(lastNameTxtBox.Text) ||
                    string.IsNullOrWhiteSpace(phoneNumberTxtBox.Text) ||
                    string.IsNullOrWhiteSpace(addressTxtBox.Text) ||
                    (!femaleRadioButton.Checked && !maleRadioButton.Checked))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(idTxtBox.Text, out int id))
                {
                    MessageBox.Show("Invalid ID format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (phoneNumberTxtBox.Text.Length != 10)
                {
                    MessageBox.Show("Phone number must be 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string fname = firstNameTxtBox.Text.Trim();
                string lname = lastNameTxtBox.Text.Trim();
                DateTime bdate = dobDateTimePicker.Value;
                string phone = phoneNumberTxtBox.Text.Trim();
                string address = addressTxtBox.Text.Trim();
                string gender = femaleRadioButton.Checked ? "Female" : "Male";
                
                int born_year = bdate.Year;
                int current_year = DateTime.Now.Year;
                int age = current_year - born_year;
                if (age < 3 || age > 90)
                {
                    MessageBox.Show("Student age must be between 3 and 90 years", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop execution
                }

                if (fname.Any(char.IsDigit) || lname.Any(char.IsDigit))
                {
                    MessageBox.Show("First name and Last name must not contain numbers", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop execution
                }

                if (!phone.All(char.IsDigit))
                {
                    MessageBox.Show("Phone number must contain digits only", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop execution
                }
                // Ensure image is provided
                byte[] picture = new byte[0];
                if (imagePictureBox.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imagePictureBox.Image.Save(ms, imagePictureBox.Image.RawFormat);
                        picture = ms.ToArray();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an image.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Prepare SQL command
                SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn, lname=@ln, bdate=@bd, gender=@gen, phone=@ph, address=@addr, picture=@pic WHERE id=@id");

                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@bd", SqlDbType.Date).Value = bdate;
                command.Parameters.Add("@gen", SqlDbType.VarChar).Value = gender;
                command.Parameters.Add("@ph", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@addr", SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@pic", SqlDbType.Image).Value = picture;

                // Execute update
                if (student.updateStudent(command))
                {
                    MessageBox.Show("Student Updated Successfully", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Updating Student", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(idTxtBox.Text);
                SqlCommand command = new SqlCommand("DELETE FROM std WHERE id=@id");
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                if (student.deleteStudent(command))
                {
                    MessageBox.Show("Student Deleted Successfully", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the form after deletion
                    idTxtBox.Text = "";
                    firstNameTxtBox.Text = "";
                    lastNameTxtBox.Text = "";
                    phoneNumberTxtBox.Text = "";
                    addressTxtBox.Text = "";
                    femaleRadioButton.Checked = false;
                    maleRadioButton.Checked = false;
                    imagePictureBox.Image = null;
                }
                else
                {
                    MessageBox.Show("Error Deleting Student", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchTxtBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTxtBox.Text.Trim();
            SqlCommand command = new SqlCommand("SELECT id, fname, lname, bdate, gender, phone, address, picture FROM std " +
                                                "WHERE fname LIKE @search OR lname LIKE @search OR phone LIKE @search OR address LIKE @search");

            command.Parameters.Add("@search", SqlDbType.VarChar).Value = "%" + searchText + "%";

            DataTable table = student.getStudents(command);

            if (table.Rows.Count > 0)
            {
                firstNameTxtBox.Text = table.Rows[0]["fname"].ToString();
                lastNameTxtBox.Text = table.Rows[0]["lname"].ToString();
                dobDateTimePicker.Value = (DateTime)table.Rows[0]["bdate"];

                // gender
                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    femaleRadioButton.Checked = true;
                }
                else
                {
                    maleRadioButton.Checked = true;
                }

                phoneNumberTxtBox.Text = table.Rows[0]["phone"].ToString();
                addressTxtBox.Text = table.Rows[0]["address"].ToString();

                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                imagePictureBox.Image = Image.FromStream(picture);
            }
            else
            {
                // Clear fields if no results found
                firstNameTxtBox.Text = "";
                lastNameTxtBox.Text = "";
                dobDateTimePicker.Value = DateTime.Now;
                femaleRadioButton.Checked = false;
                maleRadioButton.Checked = false;
                phoneNumberTxtBox.Text = "";
                addressTxtBox.Text = "";
                imagePictureBox.Image = null;
            }
        }

        private void searchTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Check if Enter key is pressed
            {
                string searchText = searchTxtBox.Text.Trim();

                if (!string.IsNullOrEmpty(searchText))
                {
                    SearchingStudentList searchForm = new SearchingStudentList(searchText);
                    searchForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please enter a search term.", "Search Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void uploadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                imagePictureBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void firstNameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
