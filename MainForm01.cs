using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2_LoginForm
{
    public partial class MainForm01 : Form
    {
        public MainForm01()
        {
            InitializeComponent();
        }

        private void MainForm01_Load(object sender, EventArgs e)
        {

        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsListForm stdList = new StudentsListForm();
            stdList.Show(this);
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStdf = new AddStudentForm();
            addStdf.Show(this);  
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsListForm stdList = new StudentsListForm();
            stdList.Show(this);
        }
    }
}
