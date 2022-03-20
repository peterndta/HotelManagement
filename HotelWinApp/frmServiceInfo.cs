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
    public partial class frmServiceInfo : Form
    {
        public frmServiceInfo()
        {
            InitializeComponent();
        }
        public IServiceRepository ServiceRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public ServiceObject ServiceInfo { get; set; }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new ServiceObject()
                {
                    ServiceID = int.Parse(txtServiceID.Text),
                    ServiceName = txtServiceName.Text,
                    ServicePrice = decimal.Parse(txtServicePrice.Text),
                };
                if(txtServiceID.Text.Trim() == string.Empty || txtServiceName.Text.Trim() ==  string.Empty 
                    || txtServicePrice.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Your field is Empty", InsertOrUpdate == false ? "Add a new service" : "Update a service");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    if (InsertOrUpdate == false)
                    {
                        ServiceRepository.InsertService(service);
                        MessageBox.Show("Add Success!");
                    }
                    else
                    {
                        ServiceRepository.UpdateService(service);
                        MessageBox.Show("Update Success!");
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new service" : "Update a service");
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmServiceInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
    

