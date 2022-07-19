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
    public partial class AddStudent : Form
    {
        U_D_I_S obj =  new U_D_I_S();
        public AddStudent()
        {
            InitializeComponent();
            List<MajorsX> listMajor = new List<MajorsX>();
            List<ClassX> listClass = new List<ClassX>();
            List<Student> listStudent = new List<Student>();
            listStudent = obj.ListStudent();
            listClass = obj.ListClass();
            listMajor = obj.ListMajors();
            for (int ig= 0; ig < listClass.Count; ig++)
            {
                comboBox1.Items.Add(listClass[ig].NameClass);
            }
            //33-54 kỷ niệm 4 ngày fix ko xong
            for(int i = 0; i < listMajor.Count; i++)
            {
                int m = 0;
                treeView1.Nodes.Add(listMajor[i].NameMajors);
                for(int j = 0; j< listClass.Count; j++)
                {

                    if (listMajor[i].NameMajors == listClass[j].NameMajors)
                    {
                        treeView1.Nodes[i].Nodes.Add(listClass[j].NameClass);    
                        for(int k = 0; k < listStudent.Count; k++)
                        {
                            if (listStudent[k].ClassSt.Equals(listClass[j].NameClass))
                            {
                                treeView1.Nodes[i].Nodes[m].Nodes.Add(listStudent[k].inforStudent());
                            }
                        }
                        m++;
                    }

                }
            }
            




            //for (int i = 0; i < listMajor.Count; i++)
            //{

            //    for (int j = 0; j < listClass.Count; j++)
            //    {
            //        if (listMajor[i].NameMajors.Equals(listClass[j].NameMajors))
            //        {
            //            for (int k = 0; k < listStudent.Count; k++)
            //            {
            //                if (listStudent[k].ClassSt.Equals(listClass[j].NameClass))
            //                {
            //                    if (i > 0 && j > 0)
            //                    {
            //                        //treeView1.Nodes[i].Nodes[j-1].Nodes.Add("Thai");
            //                    }
                                
            //                    // MessageBox.Show($"{i}-{j}-{k} \r\n {listClass[j].NameClass}-{listStudent[k].NameStudent}");
            //                    MessageBox.Show($"{listStudent[k].ClassSt}*{listClass[j].NameClass}--{i}-{j}-{k} \r\n {listMajor[i].NameMajors}-{listClass[j].NameClass}-{listStudent[k].NameStudent}");
            //                }
            //            }
            //        }
            //    }
            //}
            //treeView1.Nodes[1].Nodes[0].Nodes.Add("Thai");
            //MessageBox.Show(treeView1.Nodes[1].Nodes[0].Nodes[0].Text);
            
        }
        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //dateTimePicker1.Value.ToShortDateString()
                string gt;
                if (comboBox2.Text == "Nam") gt = "1";
                else gt = "0";
                obj.ExecuteSQL($"INSERT INTO Student VALUES ('{textBox1.Text}',N'{textBox2.Text}','{comboBox1.Text}','{dateTimePicker1.Value.ToShortDateString()}',{gt},N'{textBox6.Text}','{textBox7.Text}')");
                MessageBox.Show("Thêm thành công!");
                this.Hide();
                AddStudent f = new AddStudent();
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
                if (comboBox2.Text == "Nam") gt = "1";
                else gt = "0";
                obj.ExecuteSQL($"UPDATE Student SET NameStudent = N'{textBox2.Text}', Class = '{comboBox1.Text}', BirthDaySt = '{dateTimePicker1.Value.ToShortDateString()}',SexSt = '{gt}' , AddressStudent = N'{textBox6.Text}', NumberPhoneSt = '{textBox7.Text}' WHERE IDStudent = '{textBox1.Text}' ");
                MessageBox.Show("Sửa thành công!");
                this.Hide();
                AddStudent f = new AddStudent();
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
            ListFeatureStudent f = new ListFeatureStudent();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int m = 0;
                List<Student> list = obj.ListStudent();
                for(int i = 0; i < list.Count; i++)
                {
                    if (textBox1.Text == list[i].IDStudent)
                    {
                        MessageBox.Show(list[i].inforStudentFull());//V2 update theo các dòng
                        m++;
                    }
                }
                if (m == 0) MessageBox.Show("Không Có Trong Danh Sách!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi Không Thể Tìm!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                obj.ExecuteSQL($"DELETE Student WHERE IDStudent = '{textBox1.Text}'");
                MessageBox.Show("Xóa thành công!");
                this.Hide();
                AddStudent f = new AddStudent();
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Không thể xóa!");
            }
        }
    }
}
