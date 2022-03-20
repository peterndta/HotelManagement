using BusinessObject;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelWinApp
{
    public partial class frmRoomDetail : Form
    {
        public frmRoomDetail()
        {
            InitializeComponent();
        }
        public EmployeeObject EmployeeInfo { get; set; }
        public int roomNumber { get; set; } // Receive Room Number from Main
        public string roomType { get; set; }
        public decimal price { get; set; }
        public bool flag = false;
        public bool innerFlag = false;
        public IOrderRepository OrderRepository = new OrderRepository();
        public IOrderDetailsRepository OrderDetailsRepository = new OrderDetailsRepository();
        public ICustomerRepository CustomerRepository = new CustomerRepository();
        //Data for sending back to Main
        public static string CustomerNameValue = "";
        public static string NumberCustomerValue = "";
        public static string NationalityValue = "";
        public static string CheckInValue = "";
        public static string CheckOutValue = "";
        public static int isRoom = 0;

        public IServiceRepository serviceRepository = new ServiceRepository();
        public decimal totalItemServicePrice = 0;
        public List<int> listQuanity = new List<int>();
        public int indexComboBox = 0;
        public List<ServiceObject> tempListService = new List<ServiceObject>();
        BindingSource source;

        //-------------------------------
        public OrderObject CustomerInfo { get; set; }
        private void frmRoomDetail_Load(object sender, EventArgs e)
        {
            LoadOrderList();
            LoadCustomerList();
            firstLoad();
            List<ServiceObject> listService = null;

            listService = serviceRepository.GetServices().ToList<ServiceObject>();
            listService.ForEach(service => comboBox1.Items.Add(service.ServiceName));
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void firstLoad()
        {
            var roomTypeID = OrderRepository.GetRoomByID(roomNumber).RoomTypeID;
            roomType = OrderRepository.GetRoomTypeByID(roomTypeID).RoomType;
            price = OrderRepository.GetRoomByID(roomNumber).RoomPrice;

            txtRoomNumber.Text = roomNumber.ToString();
            txtRoomType.Text = roomType.ToString();
            txtRoomPrice.Text = price.ToString();
            lbTotalDetailInfo.Text = price.ToString();
            lbTotalAll.Text = price.ToString();
            ClearText();

            txtRoomNumber.Enabled = false;
            txtRoomType.Enabled = false;
            txtRoomPrice.Enabled = false;
        }

        private void ClearText()
        {
            txtOrderID.Text = "";
            dtpCheckInDay.Value = DateTime.Now;
            txtCustomerName.Text = "";
            txtCustomerID.Text = "";
            txtNationality.Text = "";
            txtNumberOfCustomer.Text = "1";
            dtpCheckOutDay.Value = DateTime.Now;
        }

        private List<ServiceObject> GetServiceObjects()
        {
            
            List<ServiceObject> list = new List<ServiceObject>();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                ServiceObject dv = new ServiceObject();
                dv.ServiceID = int.Parse(row.Cells["ServiceID"].Value + "");
                dv.ServiceName = row.Cells[2].Value + "";
                dv.ServicePrice = int.Parse(row.Cells[3].Value + "");
                list.Add(dv);
            }

            return list;
        }
        private void btnAddService_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag == false)
                {
                    MessageBox.Show("Please Submit first!", "Add Service Alert");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    //Save to database
                    saveOrderDetail();
                    LoadOrderDetailList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void saveOrderDetail()
        {
            try
            {
                var listService = serviceRepository.GetServices().ToList<ServiceObject>();
                var serviceId = listService.ElementAt(indexComboBox).ServiceID;
                ServiceObject service = serviceRepository.GetServicesByID(serviceId);
                totalItemServicePrice += int.Parse(txtQuanity.Text) * service.ServicePrice;
                var total = totalItemServicePrice + price;

                //Display on label
                lbserviceprice.Text = totalItemServicePrice.ToString();
                lbTotalAll.Text = total.ToString();
                //------------------------------------------

                IEnumerable<OrderDetailObject> details = OrderDetailsRepository.GetOrderDetail();

                int maxid = details.Max(t => t.DetailsID);

                var detailID = 0;

                if (details == null)
                {
                    detailID = 1;
                    var orderDetail = new OrderDetailObject
                    {
                        DetailsID = detailID,
                        OrderID = int.Parse(txtOrderID.Text), //done
                        ServiceID = serviceId,
                        ServicePrice = service.ServicePrice,
                        Quantity = int.Parse(txtQuanity.Text),
                        Total = total,
                    };
                    if (txtOrderID.Text.Trim() == string.Empty || txtCustomerID.Text.Trim() == string.Empty ||
                        txtRoomType.Text.Trim() == string.Empty || txtNumberOfCustomer.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Your field is Empty", "Add Alert");
                        DialogResult = DialogResult.None;
                    }
                    else
                    {
                        OrderDetailsRepository.InsertOrderDetail(orderDetail);
                        MessageBox.Show("Submit Success!", "Add Service Alert");
                        innerFlag = true;
                    }
                }
                else
                {
                    detailID =  maxid + 1;
                    var orderDetail = new OrderDetailObject
                    {
                        DetailsID = detailID,
                        OrderID = int.Parse(txtOrderID.Text), //done
                        ServiceID = serviceId,
                        ServicePrice = service.ServicePrice,
                        Quantity = int.Parse(txtQuanity.Text),
                        Total = total,
                    };
                    if (txtOrderID.Text.Trim() == string.Empty || txtCustomerID.Text.Trim() == string.Empty ||
                        txtRoomType.Text.Trim() == string.Empty || txtNumberOfCustomer.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Your field is Empty", "Add Alert");
                        DialogResult = DialogResult.None;
                    }
                    else
                    {
                        OrderDetailsRepository.InsertOrderDetail(orderDetail);
                        MessageBox.Show("Submit Success!", "Add Service Alert");
                        innerFlag = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Service Alert");
            }
        }
        public void LoadOrderList()
        {
            List<OrderObject> listorders = null;

            listorders = OrderRepository.GetOrderList().ToList<OrderObject>();
                
            if (listorders != null)
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = listorders;

                    dgvOrder.DataSource = null;  // Clear grid data
                    dgvOrder.DataSource = source;
                    
                    dgvOrder.Columns[0].Width = 76;
                    dgvOrder.Columns[1].Visible = false;
                    dgvOrder.Columns[2].Visible = false;
                    dgvOrder.Columns[3].Visible = false;
                    dgvOrder.Columns[4].Visible = false;
                    dgvOrder.Columns[5].Visible = false;
                    dgvOrder.Columns[6].Visible = false;
                    dgvOrder.Columns[7].Visible = false;
                    dgvOrder.Columns[8].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load order list");
                }
            }
            else
            {
                MessageBox.Show("Empty Data", "Alert");
            }
        }  
        public void LoadCustomerList()
        {
            List<CustomerObject> listcustomers = null;

            listcustomers = CustomerRepository.GetCustomers().ToList<CustomerObject>();
                
            if (listcustomers != null)
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = listcustomers;

                    lbNameFromID.DataBindings.Clear();

                    lbNameFromID.DataBindings.Add("Text", source, "NameCustomer");

                    dgvCustomer.DataSource = null;
                    dgvCustomer.DataSource = source;
                    dgvCustomer.Columns[0].Width = 90;
                    dgvCustomer.Columns[1].Visible = false;
                    dgvCustomer.Columns[2].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load customer list");
                }
            }
            else
            {
                MessageBox.Show("Empty Data", "Alert");
            }
        }

        public void LoadOrderDetailList()
        {
            List<OrderDetailObject> listdetails = null;

            listdetails = OrderDetailsRepository.GetDetailsByOrderID(int.Parse(txtOrderID.Text)).ToList<OrderDetailObject>();
            if (listdetails != null)
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = listdetails;

                    // Clear binding data
                    comboBox1.DataBindings.Clear();
                    txtQuanity.DataBindings.Clear();
                    lbID.DataBindings.Clear();


                    lbID.DataBindings.Add("Text", source, "DetailsID");
                    txtQuanity.DataBindings.Add("Text", source, "Quantity");

                    dataGridView1.DataSource = null;  
                    dataGridView1.DataSource = source;


                    if (listdetails.Count() == 0 || innerFlag == false)
                    {
                        txtQuanity.Text = "";
                        comboBox1.SelectedIndex = 0;
                        btn_DeleteService.Enabled = false;
                    }
                    else
                    {
                        btn_DeleteService.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load employee list");
                }
            }
            else
            {
                MessageBox.Show("Empty Data", "Alert");
            }
        }

        public void saveOrder()
        {
            try
            {
                var order = new OrderObject
                {
                    OrderID = int.Parse(txtOrderID.Text),
                    EmployeeID = EmployeeInfo.EmployeeID,
                    CustomerID = int.Parse(txtCustomerID.Text),
                    RoomID = roomNumber,
                    RoomType = roomType,
                    CheckInDay = dtpCheckInDay.Value,
                    NumberOfCustomer = int.Parse(txtNumberOfCustomer.Text),
                    OrderDay = dtpCheckOutDay.Value,
                    Total = Decimal.Parse(lbTotalDetailInfo.Text),

                };
                if (txtOrderID.Text.Trim() == string.Empty || txtCustomerID.Text.Trim() == string.Empty ||
                    txtRoomType.Text.Trim() == string.Empty || txtNumberOfCustomer.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Your field is Empty", "Add Alert");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    OrderRepository.InsertOrder(order);
                    MessageBox.Show("Submit Success!", "Submit alert");
                    LoadOrderList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Order Alert");
            }
        }

        public void saveCustomer()
        {
            try
            {
                var customer = new CustomerObject
                {
                    CustomerID = int.Parse(txtCustomerID.Text),
                    NameCustomer = txtCustomerName.Text,
                    Nationality = txtNationality.Text,
                };
                if (txtCustomerID.Text.Trim() == string.Empty || txtCustomerName.Text.Trim() == string.Empty ||
                    txtNationality.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Your field is Empty", "Add Alert");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    OrderRepository.InsertCustomer(customer);
                    MessageBox.Show("Customer Save Success!", "Customer alert");
                    LoadCustomerList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Customer Alert");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("This data will save to Main Screen?", "Save alert", MessageBoxButtons.YesNo);
            if (alert == DialogResult.Yes)
            {
                if (txtCustomerID.Text.Trim() == string.Empty || txtCustomerName.Text.Trim() == string.Empty ||
                    txtNationality.Text.Trim() == string.Empty || txtOrderID.Text.Trim() == string.Empty ||
                    txtRoomType.Text.Trim() == string.Empty || txtNumberOfCustomer.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Your field is Empty", "Save Alert");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    if (flag == false)
                    {
                        MessageBox.Show("Please Submit first!", "Save Alert");
                        DialogResult = DialogResult.None;
                    }
                    else
                    {
                        CustomerNameValue = txtCustomerName.Text;
                        NumberCustomerValue = txtNumberOfCustomer.Text;
                        NationalityValue = txtNationality.Text;
                        CheckInValue = dtpCheckInDay.Text;
                        CheckOutValue = dtpCheckOutDay.Text;
                        isRoom = roomNumber;
                        MessageBox.Show("Save Success!", "Save alert");
                    }
                }
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("This data will save to Database?", "Submit alert", MessageBoxButtons.YesNo);
            if (alert == DialogResult.Yes)
            {
                if (txtCustomerID.Text.Trim() == string.Empty || txtCustomerName.Text.Trim() == string.Empty ||
                    txtNationality.Text.Trim() == string.Empty || txtOrderID.Text.Trim() == string.Empty ||
                    txtRoomType.Text.Trim() == string.Empty || txtNumberOfCustomer.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Your field is Empty", "Submit Alert");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    var checkCustomer = OrderRepository.GetCustomerByID(int.Parse(txtCustomerID.Text));
                    if (checkCustomer != null)
                    {
                        txtCustomerID.Text = checkCustomer.CustomerID.ToString();
                        txtCustomerName.Text = checkCustomer.NameCustomer;
                        txtNationality.Text = checkCustomer.Nationality;
                    }
                    var numberCustomer = txtNumberOfCustomer.Text;
                    if (numberCustomer == null || numberCustomer.Trim() == string.Empty || numberCustomer == "0")
                    {
                        MessageBox.Show("Please check number again!", "Submit Alert");
                        DialogResult = DialogResult.None;
                    }
                    else
                    {
                        saveCustomer();
                        if (OrderRepository.GetOrderByID(int.Parse(txtOrderID.Text)) == null)
                        {
                            price = price * Decimal.Parse(numberCustomer);
                        }
                        lbTotalDetailInfo.Text = price.ToString();
                        lbTotalAll.Text = price.ToString();
                        saveOrder();
                        flag = true;
                    }
                }
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            firstLoad();
            comboBox1.SelectedIndex = 0;
            txtQuanity.Text = "";
        }

        private void txtOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumberOfCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuanity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexComboBox = comboBox1.SelectedIndex;
        }

        private void btn_DeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert = MessageBox.Show("Are you sure?", "Delete Detail", MessageBoxButtons.OKCancel);
                if (alert == DialogResult.OK)
                {
                    int id = int.Parse(lbID.Text);

                    OrderDetailObject detailObj = OrderDetailsRepository.GetOrderDetailsByID(id);

                    decimal priceByQuantity = detailObj.ServicePrice * detailObj.Quantity;
                    totalItemServicePrice -= priceByQuantity;

                    OrderDetailsRepository.DeleteOrderService(id);
                    LoadOrderDetailList();

                    decimal lbtotal = Decimal.Parse(lbTotalAll.Text);
                    decimal total = lbtotal - priceByQuantity;

                    //Display on label
                    lbserviceprice.Text = totalItemServicePrice.ToString();
                    lbTotalAll.Text = total.ToString();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Employee");
            }
        }
    }
}
