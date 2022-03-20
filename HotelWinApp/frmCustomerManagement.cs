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
    public partial class frmCustomerManagement : Form
    {
        public frmCustomerManagement()
        {
            InitializeComponent();
        }
        public ICustomerRepository customerRepository = new CustomerRepository();
        BindingSource source;
        private IEnumerable<CustomerObject> CustomerList;
        public void LoadCustomerList()
        {



            List<CustomerObject> listCustomer = null;

            listCustomer = customerRepository.GetCustomers().ToList<CustomerObject>();
            if (listCustomer != null)
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = listCustomer;

                    dgvCustomer.DataSource = null;  // Clear grid data
                    dgvCustomer.DataSource = source;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load room list");
                }
            }
            else
            {
                MessageBox.Show("Empty Data", "Alert");
            }

        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCustomerList();

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbSearchBy.Text == "ID")
                {
                    int customerID = int.Parse(txtSearch.Text);
                    CustomerList = customerRepository.GetCustomerByID(customerID);
                }
                else if (cbSearchBy.Text == "Name")
                {
                    string customerName = txtSearch.Text;
                    CustomerList = customerRepository.GetCustomers().Where(s => s.NameCustomer.Contains(customerName));
                }
                else if (cbSearchBy.Text == "Nationality")
                {
                    string nationality = txtSearch.Text;
                    CustomerList = customerRepository.GetCustomers().Where(s => s.Nationality.Contains(nationality));
                }
                if(CustomerList != null)
                {
                    source = new BindingSource();
                    source.DataSource = CustomerList;
                    dgvCustomer.DataSource = null;
                    dgvCustomer.DataSource = source;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("This Customer does not exist!", "Search Customer");
            }
        }

        private void frmCustomerManagement_Load(object sender, EventArgs e)
        {
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}

