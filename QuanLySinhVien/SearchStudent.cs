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
    public partial class SearchStudent : Form
    {
        U_D_I_S obj = new U_D_I_S();
        public SearchStudent()
        {
            InitializeComponent();
            DataTable dt = obj.ListSearch("SELECT * FROM Student");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView2.DataSource = dt;
            }
            dataGridView1.Columns[0].HeaderText = "MSSV";
            dataGridView1.Columns[1].HeaderText = "Họ và tên";
            dataGridView1.Columns[2].HeaderText = "Lớp";
            dataGridView1.Columns[3].HeaderText = "Ngày Sinh";
            dataGridView1.Columns[4].HeaderText = "Giới Tính";
            dataGridView1.Columns[5].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[6].HeaderText = "Số Điện Thoại";

            dataGridView2.Columns[0].HeaderText = "MSSV";
            dataGridView2.Columns[1].HeaderText = "Họ và tên";
            dataGridView2.Columns[2].HeaderText = "Lớp";
            dataGridView2.Columns[3].HeaderText = "Ngày Sinh";
            dataGridView2.Columns[4].HeaderText = "Giới Tính";
            dataGridView2.Columns[5].HeaderText = "Địa Chỉ";
            dataGridView2.Columns[6].HeaderText = "Số Điện Thoại";


        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable dt = obj.ListSearch($"SELECT * FROM Student WHERE IDStudent LIKE '%{textBox1.Text}%'");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Columns[0].HeaderText = "MSSV";
            dataGridView1.Columns[1].HeaderText = "Họ và tên";
            dataGridView1.Columns[2].HeaderText = "Lớp";
            dataGridView1.Columns[3].HeaderText = "Ngày Sinh";
            dataGridView1.Columns[4].HeaderText = "Giới Tính";
            dataGridView1.Columns[5].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[6].HeaderText = "Số Điện Thoại";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureStudent f = new ListFeatureStudent();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.ListSearch($"SELECT * FROM Student WHERE NameStudent LIKE N'%{textBox2.Text}%'");
            if (dt != null)
            {
                dataGridView2.DataSource = dt;
            }
            dataGridView2.Columns[0].HeaderText = "MSSV";
            dataGridView2.Columns[1].HeaderText = "Họ và tên";
            dataGridView2.Columns[2].HeaderText = "Lớp";
            dataGridView2.Columns[3].HeaderText = "Ngày Sinh";
            dataGridView2.Columns[4].HeaderText = "Giới Tính";
            dataGridView2.Columns[5].HeaderText = "Địa Chỉ";
            dataGridView2.Columns[6].HeaderText = "Số Điện Thoại";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureStudent f = new ListFeatureStudent();
            f.Show();
        }
    }
}
