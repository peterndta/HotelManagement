using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using Data_Access.Repository;
using HotelWinApp;

namespace HotelWinApp
{
    public partial class frmService : Form
    {
        public IServiceRepository serviceRepository = new ServiceRepository();
        BindingSource source;
        private IEnumerable<ServiceObject> ServiceList;
        public frmService()
        {
            InitializeComponent();
        }

        private void clearText()
        {
            txtServiceID.Text = string.Empty;
            txtServiceName.Text = string.Empty;
            txtServicePrice.Text = string.Empty;

        }
        //--
        private ServiceObject GetServiceObject()
        {
            ServiceObject serviceObject = null;
            try
            {
                serviceObject = new ServiceObject
                {
                    ServiceID = int.Parse(txtServiceID.Text),
                    ServiceName = txtServiceName.Text,
                    ServicePrice = decimal.Parse(txtServicePrice.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Get Service ");
            }
            return serviceObject;
        }
        public void LoadServiceList()
        {
            List<ServiceObject> listService = null;

            listService = serviceRepository.GetServices().ToList<ServiceObject>();
            if (listService != null)
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = listService;

                    // Clear binding data
                    txtServiceID.DataBindings.Clear();
                    txtServiceName.DataBindings.Clear();
                    txtServicePrice.DataBindings.Clear();



                    txtServiceID.DataBindings.Add("Text", source, "ServiceID");
                    txtServiceName.DataBindings.Add("Text", source, "ServiceName");
                    txtServicePrice.DataBindings.Add("Text", source, "ServicePrice");



                    dataGridView.DataSource = null;  // Clear grid data
                    dataGridView.DataSource = source;


                    if (listService.Count() == 0)
                    {
                        clearText();
                        btnDelete.Enabled = false;
                    }
                    else
                    {

                        btnDelete.Enabled = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load serivce list");
                }
            }
            else
            {
                MessageBox.Show("Empty Data", "Alert");
            }
        }
      
         
      
     
        private void frmService_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            LoadServiceList();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            frmServiceInfo frmServiceInfo = new frmServiceInfo
            {
                Text = "Add New serivce",
                InsertOrUpdate = false,
                ServiceRepository = serviceRepository,
            };
            if (frmServiceInfo.ShowDialog() == DialogResult.OK)
            {
                LoadServiceList();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

            try
            {
                DialogResult alert = MessageBox.Show("Are you sure?", "Delete service", MessageBoxButtons.OKCancel);
                if (alert == DialogResult.OK)
                {
                    ServiceObject Service = GetServiceObject();
                    serviceRepository.DeleteService(Service.ServiceID);
                    LoadServiceList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete service");
            }
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmServiceInfo frmServiceInfo = new frmServiceInfo
            {
                Text = "Service Info",
                InsertOrUpdate = true,
                ServiceInfo = GetServiceObject(),
                ServiceRepository = serviceRepository,
            };
            if (frmServiceInfo.ShowDialog() == DialogResult.OK)
            {
                LoadServiceList();
                source.Position = source.Count - 1;
            }
        }
    }
}