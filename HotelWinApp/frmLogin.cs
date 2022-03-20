using BusinessObject;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelWinApp
{
    public partial class frmLogin : Form
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain frmMain;
            var Username = txtUsername.Text;
            var Password = txtPassword.Text;

            //Get Admin account from json
            EmployeeObject loginInfo = employeeRepository.Login(Username, Password);

            if (loginInfo != null) //check if member
            {
                frmMain = new frmMain
                {
                    EmployeeInfo = loginInfo,
                };
                this.Hide();
                frmMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Your account does not exist!", "Alert");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
