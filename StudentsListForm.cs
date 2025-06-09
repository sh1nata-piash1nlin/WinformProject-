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

namespace L2_LoginForm
{
    public partial class StudentsListForm : Form
    {
        public StudentsListForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        private void StudentsListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDBDataSet.std' table. You can move, or remove it, as needed.
            this.stdTableAdapter.Fill(this.qLSVDBDataSet.std);
            SqlCommand command = new SqlCommand("SELECT * FROM std");
            dataGridView.ReadOnly = true;
            //xu ly hinh anh, code tham khao msdn 
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView.RowTemplate.Height = 80;
            dataGridView.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.stdTableAdapter.Fill(this.qLSVDBDataSet.std);
            SqlCommand command = new SqlCommand("SELECT * FROM std");
            dataGridView.ReadOnly = true;
            //xu ly hinh anh, code tham khao msdn 
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView.RowTemplate.Height = 80;
            dataGridView.DataSource = student.getStudents(command);
            picCol = (DataGridViewImageColumn)dataGridView.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView.AllowUserToAddRows = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM std");

            // Get student data from the database
            DataTable table = student.getStudents(command);

            // Bind the data to the DataGridView
            dataGridView.DataSource = table;

            // Ensure images are displayed correctly
            DataGridViewImageColumn picCol = (DataGridViewImageColumn)dataGridView.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            // Adjust row height for better visibility
            dataGridView.RowTemplate.Height = 80;

            // Prevent users from adding new rows manually
            dataGridView.AllowUserToAddRows = false;
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDeletStdf = new UpdateDeleteStudentForm();

            // thu tu cua cac cot: id - fname - lname - bd - gdr - phn - adrs - pic
            updateDeletStdf.idTxtBox.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            updateDeletStdf.firstNameTxtBox.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            updateDeletStdf.lastNameTxtBox.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            updateDeletStdf.dobDateTimePicker.Value = (DateTime)dataGridView.CurrentRow.Cells[3].Value;

            // gender
            string gender = dataGridView.CurrentRow.Cells[4].Value.ToString().Trim(); // Trim to remove spaces
            if (gender == "Female")
            {
                updateDeletStdf.femaleRadioButton.Checked = true;
                updateDeletStdf.maleRadioButton.Checked = false;  // Explicitly uncheck male
            }
            else if (gender == "Male")
            {
                updateDeletStdf.maleRadioButton.Checked = true;
                updateDeletStdf.femaleRadioButton.Checked = false; // Explicitly uncheck female
            }

            updateDeletStdf.phoneNumberTxtBox.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            updateDeletStdf.addressTxtBox.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();

            // code xu ly hinh anh up len, version 01, chay OK, tim hieu them de code nhe hon
            byte[] pic;
            pic = (byte[])dataGridView.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeletStdf.imagePictureBox.Image = Image.FromStream(picture);

            updateDeletStdf.Show();
        }
    }
}
