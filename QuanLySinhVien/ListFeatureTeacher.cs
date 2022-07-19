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
    public partial class ListFeatureTeacher : Form
    {
        public ListFeatureTeacher()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainInterface f = new MainInterface();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTeacher f = new AddTeacher();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có ý tưởng :<");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchTeacher f = new SearchTeacher();
            f.Show();
        }
    }
}
