using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureStudent f = new ListFeatureStudent();
            f.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureTeacher f = new ListFeatureTeacher();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureSchool f = new ListFeatureSchool();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    ListFeatureSchool f = new ListFeatureSchool();
        //    f.Show();
        //}
    }
}
