namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        static int dem = 2;
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn f = new SignIn();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dem %2 ==0)
            {
                textBox2.UseSystemPasswordChar = false ;
                dem = 1;
            }
            else{
                textBox2.UseSystemPasswordChar = true;
                dem++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Không được để trống!");

            }
            else
            {
                U_D_I_S obj = new U_D_I_S();
                if(obj.Select_Account(textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("Đăng nhập " + textBox1.Text + " thành công!");
                    this.Hide();
                    MainInterface f = new MainInterface();
                    f.Show();

                }
                else
                {
                    MessageBox.Show("Tài khoản " + textBox1.Text + " chưa được đăng ký!");
                }
                
            }
        }
    }
}