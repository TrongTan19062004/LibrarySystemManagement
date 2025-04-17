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
    public partial class FrmPersonalProfile : Form
    {
        public FrmPersonalProfile()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PersonalProfile_Load(object sender, EventArgs e)
        {
            //    string cnStr = "Data Source=LAPTOP-H6KBR02F\\SQLEXPRESS01;Initial Catalog=LibraryManagementDatabase;Integrated Security=True;TrustServerCertificate=True";
            //    SqlConnection cn = new SqlConnection(cnStr);
            //    String sql = "select "+ txtEmail.Text+" , "+dtPersonal.Text+" , "+txtEmail.Text+" , "+ txtPhone.Text+","+txtCountry.Text+" from Users";

            //    SqlCommand cmd = new SqlCommand(sql, cn);
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    cmd.CommandType = CommandType.Text;
            //    DataTable dataTable = new DataTable();
            //    adapter.Fill(dataTable);
            if (UserService.Instance.account != null)
            {
                txtName.Text= UserService.Instance.account.Name;
                txtCountry.Text= UserService.Instance.account.Country;
                txtEmail.Text= UserService.Instance.account.Email;
                txtPhone.Text= UserService.Instance.account.Phone;
                dtPersonal.Value = UserService.Instance.account.NgaySinh;
            }
            else
            {
                txtName.Text = "abc";
            }
            

        }
    }
}
