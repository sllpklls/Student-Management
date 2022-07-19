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
    public partial class AddTeacher : Form
    {
        U_D_I_S obj =  new U_D_I_S();
        public AddTeacher()
        {
            InitializeComponent();
            DataTable dt = obj.ListSearch("SELECT * FROM Teacher");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Columns[0].HeaderText = "Mã GV";
            dataGridView1.Columns[1].HeaderText = "Họ và tên";
            dataGridView1.Columns[2].HeaderText = "Giới Tính";
            dataGridView1.Columns[3].HeaderText = "Môn Giảng Dạy";
            dataGridView1.Columns[4].HeaderText = "Số Điện Thoại";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //dateTimePicker1.Value.ToShortDateString()
                string gt;
                if (comboBox1.Text == "Nam") gt = "1";
                else gt = "0";
                obj.ExecuteSQL($"INSERT INTO Teacher VALUES ('{textBox1.Text}',N'{textBox2.Text}','{gt}',N'{textBox4.Text}','{textBox5.Text}')");
                MessageBox.Show("Thêm thành công!");
                this.Hide();
                AddTeacher f = new AddTeacher();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Không Thể Thêm!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string gt;
                if (comboBox1.Text == "Nam") gt = "1";
                else gt = "0";
                obj.ExecuteSQL($"UPDATE Teacher SET NameTeacher = N'{textBox2.Text}', SexTe = '{gt}', SubjectTeacher = N'{textBox4.Text}', NumberPhoneTe = '{textBox5.Text}' WHERE IDTeacher = '{textBox1.Text}'");
                MessageBox.Show("Sửa thành công!");
                this.Hide();
                AddTeacher f = new AddTeacher();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Không Thể Sửa!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureTeacher f = new ListFeatureTeacher();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int m = 0;
                List<Teacher> list = obj.ListTeacher();
                for (int i = 0; i < list.Count; i++)
                {
                    if (textBox1.Text == list[i].IDTeacher)
                    {
                        MessageBox.Show(list[i].inforTeacherFull());//V2 update theo các dòng
                        m++;
                    }
                }
                if (m == 0) MessageBox.Show("Không Có Trong Danh Sách!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteSQL($"DELETE Teacher WHERE IDTeacher = '{textBox1.Text}'");
                MessageBox.Show("Xóa thành công!");
                this.Hide();
                AddTeacher f = new AddTeacher();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể xóa!");
            }
        }
    }
}
