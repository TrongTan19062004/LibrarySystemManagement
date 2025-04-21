using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using TransferObject;
namespace PresentationLayer
{
    public partial class Home : Form
    {
        private Account account;
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            account = new Account();
            
            lbWelcomeUser.Text = "Chao mung user den voi phan mem quan ly thu vien";

        }

        private void viewPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonalProfile frmPersonalProfile = new FrmPersonalProfile();
            frmPersonalProfile.ShowDialog();

        }
    }
}
