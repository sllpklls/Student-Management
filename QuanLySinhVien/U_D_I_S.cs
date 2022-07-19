using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace QuanLySinhVien
{
    internal class U_D_I_S //Update_Delete_Insert_Select
    {
        //static Action<string, string> action;
        static string sqlconnectStr = "Data Source=SLLPKLLS\\SQLEXPRESS;Initial Catalog=QLSV;User ID=sa;Password=hoangthaifc01";
        public U_D_I_S() { }
        public void InSert_New_Account(string _ID, string _Password)
        {   try
            {
                using var connection = new SqlConnection(sqlconnectStr);
                using var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO Account VALUES ('{_ID}','{_Password}')";
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }
        public bool Select_Account(string _ID, string _Password)
        {
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT * FROM Account WHERE ID = '{_ID}' AND PWD ='{_Password}'";
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // có dòng dữ liệu trả true 
                {
                    connection.Close();
                    return true;
                }
                else return false;
            }
        }
        public List<MajorsX> ListMajors()
        {
            List<MajorsX> list = new List<MajorsX>();
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Majors";
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // có dòng dữ liệu trả true 
                {
                    while (reader.Read())
                    {
                        list.Add(new MajorsX(reader["IDMajors"].ToString(), reader["NameMajors"].ToString(), reader["Amount"].ToString(), reader["Note"].ToString()));
                        //list.Add(reader["IDMajors"].ToString());
                        //list.Add(reader["NameMajors"].ToString());
                        //list.Add(reader["Amount"].ToString());
                        //list.Add(reader["Note"].ToString());

                    }
                    connection.Close();
                    return list;
                }
                
            }
            connection.Close();
            return list;
        }
        public List<ClassX> ListClass()
        {
            List<ClassX> list = new List<ClassX>();
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Class";
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // có dòng dữ liệu trả true 
                {
                    while (reader.Read())
                    {
                        //ClassX x = new ClassX(reader["NameClass"].ToString(), reader["NameMajors"].ToString(), reader["Manager"].ToString(), reader["Leader"].ToString());
                        list.Add(new ClassX(reader["NameMajors"].ToString(), reader["NameClass"].ToString(), reader["Manager"].ToString(), reader["Leader"].ToString()));
                    }
                    return list;

                }

            }
            connection.Close();
            return list;
        }
        public List<Student> ListStudent()
        {
            List<Student> list = new List<Student>();
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT * FROM Student";
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // có dòng dữ liệu trả true 
                {
                    while (reader.Read())
                    {
                        DateTime myTime = DateTime.Parse(reader[3].ToString());
                        //myTime.ToString("yyyy-MM-dd");
                        list.Add(new Student(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), myTime.ToString("yyyy-MM-dd"), reader[4].ToString(), reader[5].ToString(), reader[6].ToString()));
                    }
                    return list;

                }

            }
            connection.Close();
            return list;
        }
        public List<Teacher> ListTeacher()
        {
            List<Teacher> list = new List<Teacher>();
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT * FROM Teacher";
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // có dòng dữ liệu trả true 
                {
                    while (reader.Read())
                    {
                        list.Add(new Teacher(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
                    }
                    return list;

                }

            }
            connection.Close();
            return list;
        }
        public void ExecuteSQL(string S)
        {
                using var connection = new SqlConnection(sqlconnectStr);
                using var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = S;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close(); 
        }
        public int CountSQL(string S)
        {
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = S;
            connection.Open();
            //return Convert.ToInt32(reader[1].ToString());
            return (Int32)command.ExecuteScalar();
        }
        public DataTable ListSearch(string cmd) 
        {
            DataTable da = new DataTable();
            try
            {
                using var connection = new SqlConnection(sqlconnectStr);
                using var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(da);
            }
            catch (Exception)
            {
                da = null;
            }
            return da;
        }

    }
}
