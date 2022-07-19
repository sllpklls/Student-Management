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
    public partial class AddMajors : Form
    {
        static U_D_I_S obj = new U_D_I_S();
        public AddMajors()
        {
            InitializeComponent();
            textBox5.Text = obj.CountSQL("SELECT COUNT(IDMajors) FROM Majors").ToString();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Mã Ngành Học", 70);
            listView1.Columns.Add("Tên Ngành Học", 200);
            listView1.Columns.Add("Số Lượng", 50);
            listView1.Columns.Add("Ghi Chú", 400);
            string[] arr = new string[4];
            //U_D_I_S obj = new U_D_I_S();
            List<MajorsX> list = obj.ListMajors();
            for(int i = 0; i < list.Count; i++)
            {
                arr[0]= list[i].IDMajors;
                arr[1]= list[i].NameMajors;
                arr[2] = list[i].Amount;
                arr[3] = list[i].Note;
                listView1.Items.Add(new ListViewItem(arr));
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteSQL($"INSERT INTO Majors VALUES ('{textBox1.Text}',N'{textBox2.Text}',{textBox3.Text},N'{textBox4.Text}')");
                MessageBox.Show("Thêm thành công!");
                this.Hide();
                AddMajors f = new AddMajors();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể thêm!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //UPDATE Majors SET NameMajors = N'textBox2.Text', Amount = textBox3.Text, Note = N'textBox4.Text' WHERE IDMajors = 'textBox1.Text'
                obj.ExecuteSQL($"UPDATE Majors SET NameMajors = N'{textBox2.Text}', Amount = {textBox3.Text}, Note = N'{textBox4.Text}' WHERE IDMajors = '{textBox1.Text}'");
                MessageBox.Show("Sửa thành công!");
                this.Hide();
                AddMajors f = new AddMajors();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể sửa!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tìm refesh lại combobox coming soon
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteSQL($"DELETE Majors WHERE IDMajors = '{textBox1.Text}'");
                MessageBox.Show("Xóa thành công!");
                this.Hide();
                AddMajors f = new AddMajors();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể xóa!");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureSchool f = new ListFeatureSchool();
            f.Show();
        }
    }
}
