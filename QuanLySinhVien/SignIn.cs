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
    public partial class SignIn : Form
    {
        static int dem = 1;
        public SignIn()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dem % 2 == 0)
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
                dem = 1;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
                dem++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == ""||textBox2.Text ==""||textBox3.Text == "")
            {
                MessageBox.Show("Không được để trống!");
            }
            else
            {
                if(textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Xác nhận mật khẩu không trùng!");
                }
                else
                {
                    U_D_I_S obj = new U_D_I_S();
                    obj.InSert_New_Account(textBox1.Text, textBox2.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
