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
    public partial class AddClass : Form
    {
        static U_D_I_S obj = new U_D_I_S();
        public AddClass()
        {
            InitializeComponent();
            textBox5.Text = obj.CountSQL("SELECT COUNT(NameClass) FROM Class").ToString();
            List<MajorsX> types = new List<MajorsX>();
            types = obj.ListMajors();
            for (int n = 0; n < types.Count; n++)
            {
                comboBox1.Items.Add(types[n].NameMajors);
            }

            List<MajorsX> list = new List<MajorsX>();
            List<ClassX> list2 = new List<ClassX>();
            list = obj.ListMajors();
            list2 = obj.ListClass();
            for(int i = 0; i < list.Count; i++)
            {
                treeView1.Nodes.Add(list[i].NameMajors);
                for (int  j=0;j< list2.Count; j++)
                {
                    if (list[i].NameMajors.Equals(list2[j].NameMajors))
                    {
                        treeView1.Nodes[i].Nodes.Add(list2[j].NameClass);
                    }
                    //treeView1.Nodes[i].Nodes.Add("thái");
                    //}
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteSQL($"INSERT INTO Class VALUES (N'{comboBox1.Text}',N'{textBox2.Text}',N'{textBox3.Text}',N'{textBox4.Text}')");
                MessageBox.Show("Thêm thành công!");
                this.Hide();
                AddClass f = new AddClass();
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
                obj.ExecuteSQL($"UPDATE Class SET NameMajors = N'{comboBox1.Text}', Manager = N'{textBox3.Text}', Leader = '{textBox4.Text}' WHERE NameClass = '{textBox2.Text}'");
                MessageBox.Show("Sửa thành công!");
                this.Hide();
                AddClass f = new AddClass();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể sửa!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteSQL($"DELETE Class WHERE NameClass = '{textBox2.Text}'");
                MessageBox.Show("Xóa thành công!");
                this.Hide();
                AddClass f = new AddClass();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể xóa!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListFeatureSchool f = new ListFeatureSchool();
            f.Show();
        }
    }
}
