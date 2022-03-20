using BusinessObject;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelWinApp
{
    public partial class frmEmployeeInfo : Form
    {
        public frmEmployeeInfo()
        {
            InitializeComponent();
        }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public EmployeeObject EmployeeInfo { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var employee = new EmployeeObject
                {
                    EmployeeID = int.Parse(txtEmployeeID.Text),
                    EmployeeName = txtEmployeeName.Text,
                    PathImage = txtPathImage.Text,
                    username = txtUsername.Text,
                    password = txtPassword.Text,

                };
                if (txtEmployeeID.Text.Trim() == string.Empty || txtEmployeeName.Text.Trim() == string.Empty ||
                    txtPathImage.Text.Trim() == string.Empty || txtUsername.Text.Trim() == string.Empty ||
                    txtPassword.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Your field is Empty", InsertOrUpdate == false ? "Add a new employee" : "Update a employee");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    if (InsertOrUpdate == false)
                    {
                        EmployeeRepository.InsertEmployee(employee);
                        MessageBox.Show("Add Success!");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        EmployeeRepository.UpdateEmployee(employee);
                        MessageBox.Show("Update Success!");
                        DialogResult = DialogResult.Cancel;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new employee" : "Update a employee");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEmployeeInfo_Load(object sender, EventArgs e)
        {
            txtEmployeeID.Enabled = !InsertOrUpdate;
            pbAvatar.ImageLocation = "https://scontent.fsgn2-1.fna.fbcdn.net/v/t1.15752-9/262001845_1055909935244014_5692229331496225728_n.png?_nc_cat=105&ccb=1-5&_nc_sid=ae9488&_nc_ohc=fnLtEwUF1AYAX_Kv6_l&_nc_ht=scontent.fsgn2-1.fna&oh=03_AVKmZkJcCe4uoWkeXwqp3jkxq6kIW_5ZqKZmnqfc7q_dLA&oe=624B8F54";
            if (InsertOrUpdate == true)
            {
                if(EmployeeInfo.PathImage.Contains("http://") || EmployeeInfo.PathImage.Contains("https://"))
                {
                    pbAvatar.ImageLocation = EmployeeInfo.PathImage;
                }
                //else
                //{
                //    pbAvatar.ImageLocation = "https://scontent.fsgn2-1.fna.fbcdn.net/v/t1.15752-9/262001845_1055909935244014_5692229331496225728_n.png?_nc_cat=105&ccb=1-5&_nc_sid=ae9488&_nc_ohc=fnLtEwUF1AYAX_Kv6_l&_nc_ht=scontent.fsgn2-1.fna&oh=03_AVKmZkJcCe4uoWkeXwqp3jkxq6kIW_5ZqKZmnqfc7q_dLA&oe=624B8F54";

                //}  
                txtEmployeeID.Text = EmployeeInfo.EmployeeID.ToString();
                txtEmployeeName.Text = EmployeeInfo.EmployeeName.ToString();
                txtPathImage.Text = EmployeeInfo.PathImage.ToString();
                txtUsername.Text = EmployeeInfo.username.ToString();
                txtPassword.Text = EmployeeInfo.password.ToString();

            }
        }
    }
}
