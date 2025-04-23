using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using TransferObject;
namespace PresentationLayer
{
    public partial class SignIn : Form
    {
        Account account;
        public SignIn()
        {
            InitializeComponent();
            int count = 3;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form formRegister = new Register();
            formRegister.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            /*
             * select * from Users u join User_Role r on u.user_Role= r.userType_id
  where user_name='Tran Thi Truc Mai' and  user_password ='mai179@' and userType_name='Staff'
             */
            string cnStr = "Data Source=LAPTOP-H6KBR02F\\SQLEXPRESS01;Initial Catalog=LibraryManagementDatabase;Integrated Security=True;TrustServerCertificate=True";
            
            SqlConnection cn = new SqlConnection(cnStr);
            cn.Open();
            string itemText = comboBox1.SelectedItem.ToString();
            String sql = "SELECT * FROM Users u join User_Role r on u.user_Role = r.userType_id  where user_username = '" + textBox1.Text+ "' and user_password = '" + textBox2.Text + "' and userType_name = '" + itemText + "'";
            
            SqlCommand cmd=new SqlCommand(sql, cn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();
           
            if (reader.Read())
            {
                int id = (int)reader["user_id"];
                int role_id = (int)reader["user_Role"];
                string name = reader["user_name"].ToString();
                DateTime? ngaysinh = reader["user_birth"] != DBNull.Value
    ? Convert.ToDateTime(reader["user_birth"])
    : (DateTime?)null;
                string country = reader["user_country"].ToString();
                string username = reader["user_username"].ToString() ;
                string password=reader["user_password"].ToString() ;
                string email = reader["user_email"].ToString();
                DateTime createdAt = reader.GetDateTime(reader.GetOrdinal("user_createdAt"));
                string phone = reader["user_phone"].ToString();
                string avatar = reader["user_avatar"].ToString();
                account=new Account(id, name, ngaysinh, username, password, role_id, createdAt, email,phone, avatar);

            }

            
            if (account !=null)
            {
                MessageBox.Show("Dang nhap thanh cong");
                Home home = new Home(account);
                
                
                home.ShowDialog();
                this.Hide();
                

            }
            else
            {
                throw new Exception("Dang nhap that bai");
            }
                cn.Close();

        }
    }
}
