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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public EmployeeObject EmployeeInfo { get; set; }
        public IOrderRepository OrderRepository = new OrderRepository();
        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowAllRoomType();

        }
        public void ShowRoomInfo()
        {
            if (frmRoomDetail.isRoom == 1)
            {
                ShowRoom1Info();
            }
            if (frmRoomDetail.isRoom == 2)
            {
                ShowRoom2Info();
            }
            if (frmRoomDetail.isRoom == 3)
            {
                ShowRoom3Info();
            }
            if (frmRoomDetail.isRoom == 4)
            {
                ShowRoom4Info();
            }
            if (frmRoomDetail.isRoom == 5)
            {
                ShowRoom5Info();
            }
            if (frmRoomDetail.isRoom == 6)
            {
                ShowRoom6Info();
            }
        }
        public void ShowRoom1Info()
        {
            lbCustomerNameInfo1.Text = frmRoomDetail.CustomerNameValue;
            lbNumberOfCustomerInfo1.Text = frmRoomDetail.NumberCustomerValue;
            lbNationalityInfo1.Text = frmRoomDetail.NationalityValue;
            lbCheckinDayInfo1.Text = frmRoomDetail.CheckInValue;
            lbCheckoutDayInfo1.Text = frmRoomDetail.CheckOutValue;
            cbRoomStatus1.Text = "Booked";
        }
        public void ShowRoom2Info()
        {
            lbCustomerNameInfo2.Text = frmRoomDetail.CustomerNameValue;
            lbNumberOfCustomerInfo2.Text = frmRoomDetail.NumberCustomerValue;
            lbNationalityInfo2.Text = frmRoomDetail.NationalityValue;
            lbCheckinDayInfo2.Text = frmRoomDetail.CheckInValue;
            lbCheckoutDayInfo2.Text = frmRoomDetail.CheckOutValue;
            cbRoomStatus2.Text = "Booked";
        }
        public void ShowRoom3Info()
        {
            lbCustomerNameInfo3.Text = frmRoomDetail.CustomerNameValue;
            lbNumberOfCustomerInfo3.Text = frmRoomDetail.NumberCustomerValue;
            lbNationalityInfo3.Text = frmRoomDetail.NationalityValue;
            lbCheckinDayInfo3.Text = frmRoomDetail.CheckInValue;
            lbCheckoutDayInfo3.Text = frmRoomDetail.CheckOutValue;
            cbRoomStatus3.Text = "Booked";
        }
        public void ShowRoom4Info()
        {
            lbCustomerNameInfo4.Text = frmRoomDetail.CustomerNameValue;
            lbNumberOfCustomerInfo4.Text = frmRoomDetail.NumberCustomerValue;
            lbNationalityInfo4.Text = frmRoomDetail.NationalityValue;
            lbCheckinDayInfo4.Text = frmRoomDetail.CheckInValue;
            lbCheckoutDayInfo4.Text = frmRoomDetail.CheckOutValue;
            cbRoomStatus4.Text = "Booked";
        }
        public void ShowRoom5Info()
        {
            lbCustomerNameInfo5.Text = frmRoomDetail.CustomerNameValue;
            lbNumberOfCustomerInfo5.Text = frmRoomDetail.NumberCustomerValue;
            lbNationalityInfo5.Text = frmRoomDetail.NationalityValue;
            lbCheckinDayInfo5.Text = frmRoomDetail.CheckInValue;
            lbCheckoutDayInfo5.Text = frmRoomDetail.CheckOutValue;
            cbRoomStatus5.Text = "Booked";
        }
        public void ShowRoom6Info()
        {
            lbCustomerNameInfo6.Text = frmRoomDetail.CustomerNameValue;
            lbNumberOfCustomerInfo6.Text = frmRoomDetail.NumberCustomerValue;
            lbNationalityInfo6.Text = frmRoomDetail.NationalityValue;
            lbCheckinDayInfo6.Text = frmRoomDetail.CheckInValue;
            lbCheckoutDayInfo6.Text = frmRoomDetail.CheckOutValue;
            cbRoomStatus6.Text = "Booked";
        }
        public void ShowAllRoomType()
        {
            ShowRoom1Type();
            ShowRoom2Type();
            ShowRoom3Type();
            ShowRoom4Type();
            ShowRoom5Type();
            ShowRoom6Type();
        }
        public void ShowRoom1Type()
        {
            var room1TypeID = OrderRepository.GetRoomByID(1).RoomTypeID;
            var type = OrderRepository.GetRoomTypeByID(room1TypeID).RoomType;
            if (type == null)
            {
                lbType1.Text = "None";
            }
            else
            {
                lbType1.Text = type;
            }
        }
        public void ShowRoom2Type()
        {
            var room2TypeID = OrderRepository.GetRoomByID(2).RoomTypeID;
            var type = OrderRepository.GetRoomTypeByID(room2TypeID).RoomType;
            if (type == null)
            {
                lbType2.Text = "None";
            }
            else
            {
                lbType2.Text = type;
            }
        }
        public void ShowRoom3Type()
        {
            var room3TypeID = OrderRepository.GetRoomByID(3).RoomTypeID;
            var type = OrderRepository.GetRoomTypeByID(room3TypeID).RoomType;
            if (type == null)
            {
                lbType3.Text = "None";
            }
            else
            {
                lbType3.Text = type;
            }
        }
        public void ShowRoom4Type()
        {
            var room4TypeID = OrderRepository.GetRoomByID(4).RoomTypeID;
            var type = OrderRepository.GetRoomTypeByID(room4TypeID).RoomType;
            if (type == null)
            {
                lbType4.Text = "None";
            }
            else
            {
                lbType4.Text = type;
            }
        }
        public void ShowRoom5Type()
        {
            var room5TypeID = OrderRepository.GetRoomByID(5).RoomTypeID;
            var type = OrderRepository.GetRoomTypeByID(room5TypeID).RoomType;
            if (type == null)
            {
                lbType5.Text = "None";
            }
            else
            {
                lbType5.Text = type;
            }
        }
        public void ShowRoom6Type()
        {
            var room6TypeID = OrderRepository.GetRoomByID(6).RoomTypeID;
            var type = OrderRepository.GetRoomTypeByID(room6TypeID).RoomType;
            if (type == null)
            {
                lbType6.Text = "None";
            }
            else
            {
                lbType6.Text = type;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult alert = MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo);
            if (alert == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmployeesManagement frmEmployeesManagement = new frmEmployeesManagement();
                frmEmployeesManagement.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee");
            }


        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoomManagement frmRoomManagement = new frmRoomManagement();
                if (frmRoomManagement.ShowDialog() == DialogResult.Cancel)
                {
                    ShowAllRoomType();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Room");
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerManagement frmCustomerManagement = new frmCustomerManagement();
                frmCustomerManagement.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Customer");
            }
        }
        private void btnDetail1_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoomDetail frmRoomDetail = new frmRoomDetail
                {
                    roomNumber = 1,
                    EmployeeInfo = EmployeeInfo,
                };
                if (frmRoomDetail.ShowDialog() == DialogResult.OK)
                {
                    ShowRoomInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee");
            }
        }

        private void btnDetail2_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoomDetail frmRoomDetail = new frmRoomDetail
                {
                    roomNumber = 2,
                    EmployeeInfo = EmployeeInfo,
                };
                if (frmRoomDetail.ShowDialog() == DialogResult.OK)
                {
                    ShowRoomInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee");
            }
        }

        private void btnDetail3_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoomDetail frmRoomDetail = new frmRoomDetail
                {
                    roomNumber = 3,
                    EmployeeInfo = EmployeeInfo,
                };
                if (frmRoomDetail.ShowDialog() == DialogResult.OK)
                {
                    ShowRoomInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee");
            }
        }

        private void btnDetail4_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoomDetail frmRoomDetail = new frmRoomDetail
                {
                    roomNumber = 4,
                    EmployeeInfo = EmployeeInfo,
                };
                if (frmRoomDetail.ShowDialog() == DialogResult.OK)
                {
                    ShowRoomInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee");
            }
        }

        private void btnDetail5_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoomDetail frmRoomDetail = new frmRoomDetail
                {
                    roomNumber = 5,
                    EmployeeInfo = EmployeeInfo,
                };
                if (frmRoomDetail.ShowDialog() == DialogResult.OK)
                {
                    ShowRoomInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee");
            }
        }

        private void btnDetail6_Click(object sender, EventArgs e)
        {
            try
            {
                frmRoomDetail frmRoomDetail = new frmRoomDetail
                {
                    roomNumber = 6,
                    EmployeeInfo = EmployeeInfo,
                };
                if (frmRoomDetail.ShowDialog() == DialogResult.OK)
                {
                    ShowRoomInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Employee");
            }
        }

        private void btnCheckOut1_Click(object sender, EventArgs e)
        {
            lbCustomerNameInfo1.Text = "______________________";
            lbNumberOfCustomerInfo1.Text = "______________________";
            lbNationalityInfo1.Text = "______________________";
            lbCheckinDayInfo1.Text = "______________________";
            lbCheckoutDayInfo1.Text = "______________________";
            cbRoomStatus1.Text = "Cleaning";
        }

        private void btnCheckOut2_Click(object sender, EventArgs e)
        {
            lbCustomerNameInfo2.Text = "______________________";
            lbNumberOfCustomerInfo2.Text = "______________________";
            lbNationalityInfo2.Text = "______________________";
            lbCheckinDayInfo2.Text = "______________________";
            lbCheckoutDayInfo2.Text = "______________________";
            cbRoomStatus2.Text = "Cleaning";
        }

        private void btnCheckOut3_Click(object sender, EventArgs e)
        {
            lbCustomerNameInfo3.Text = "______________________";
            lbNumberOfCustomerInfo3.Text = "______________________";
            lbNationalityInfo3.Text = "______________________";
            lbCheckinDayInfo3.Text = "______________________";
            lbCheckoutDayInfo3.Text = "______________________";
            cbRoomStatus3.Text = "Cleaning";
        }

        private void btnCheckOut4_Click(object sender, EventArgs e)
        {
            lbCustomerNameInfo4.Text = "______________________";
            lbNumberOfCustomerInfo4.Text = "______________________";
            lbNationalityInfo4.Text = "______________________";
            lbCheckinDayInfo4.Text = "______________________";
            lbCheckoutDayInfo4.Text = "______________________";
            cbRoomStatus4.Text = "Cleaning";
        }

        private void btnCheckOut5_Click(object sender, EventArgs e)
        {
            lbCustomerNameInfo5.Text = "______________________";
            lbNumberOfCustomerInfo5.Text = "______________________";
            lbNationalityInfo5.Text = "______________________";
            lbCheckinDayInfo5.Text = "______________________";
            lbCheckoutDayInfo5.Text = "______________________";
            cbRoomStatus5.Text = "Cleaning";
        }

        private void btnCheckOut6_Click(object sender, EventArgs e)
        {
            lbCustomerNameInfo6.Text = "______________________";
            lbNumberOfCustomerInfo6.Text = "______________________";
            lbNationalityInfo6.Text = "______________________";
            lbCheckinDayInfo6.Text = "______________________";
            lbCheckoutDayInfo6.Text = "______________________";
            cbRoomStatus6.Text = "Cleaning";
        }

        private void btnResetStatus1_Click(object sender, EventArgs e)
        {
            cbRoomStatus1.Text = "Empty";
        }

        private void btnResetStatus2_Click(object sender, EventArgs e)
        {
            cbRoomStatus2.Text = "Empty";
        }

        private void btnResetStatus3_Click(object sender, EventArgs e)
        {
            cbRoomStatus3.Text = "Empty";
        }

        private void btnResetStatus4_Click(object sender, EventArgs e)
        {
            cbRoomStatus4.Text = "Empty";
        }

        private void btnResetStatus5_Click(object sender, EventArgs e)
        {
            cbRoomStatus5.Text = "Empty";
        }

        private void btnResetStatus6_Click(object sender, EventArgs e)
        {
            cbRoomStatus6.Text = "Empty";
        }
    }
}
