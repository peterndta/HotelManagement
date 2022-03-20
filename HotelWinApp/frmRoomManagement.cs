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

namespace HotelWinApp
{
    public partial class frmRoomManagement : Form
    {
        public frmRoomManagement()
        {
            InitializeComponent();
        }
        public IRoomRepository roomRepository = new RoomRepository();
        BindingSource source;
        private IEnumerable<RoomObject> RoomList;
        public void LoadRoomList()
        {
            List<RoomObject> listRoom = null;

            listRoom = roomRepository.GetRooms().ToList<RoomObject>();
            RoomList = listRoom;
            if (listRoom != null)
            {
                try
                {
                    source = new BindingSource();
                    source.DataSource = listRoom;

                    txtRoomID.DataBindings.Clear();
                    txtRoomType.DataBindings.Clear();

                    txtRoomID.DataBindings.Add("Text", source, "RoomID");
                    txtRoomType.DataBindings.Add("Text", source, "RoomTypeID");

                    dvgRoom.DataSource = null;  // Clear grid data
                    dvgRoom.DataSource = source;
                    dvgRoom.Columns[0].Width = 200;
                    dvgRoom.Columns[1].Width = 200;
                    dvgRoom.Columns[2].Width = 200;
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
        private void frmRoomManagement_Load(object sender, EventArgs e)
        {
            LoadRoomList();
            dvgRoom.CellDoubleClick += DvgRoom_CellDoubleClick;
            txtRoomTypeName.Text = roomRepository.GetRoomTypeByID(int.Parse(txtRoomType.Text)).RoomType;
        }

        private void DvgRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmRoomType frmRoomType = new frmRoomType
            {
                RoomInfo = GetRoomObject(),
                RoomRepository = roomRepository
            };
            if(frmRoomType.ShowDialog() == DialogResult.Cancel)
            {
                LoadRoomList();
                source.Position = source.Count - 1;
            }
        }

        private RoomObject GetRoomObject()
        {
            RoomObject room = null;
            try
            {
                var price = RoomList.SingleOrDefault(pro => pro.RoomID == int.Parse(txtRoomID.Text)).RoomPrice;
                room = new RoomObject
                {
                    RoomID = int.Parse(txtRoomID.Text),
                    RoomTypeID = int.Parse(txtRoomType.Text),
                    RoomPrice = price
                };
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get room");
            }
            return room;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnModifyService_Click(object sender, EventArgs e)
        {
            try
            {
                frmService frmService = new frmService();
                frmService.ShowDialog();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Service");
            }

        }

        private void dvgRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomTypeName.Text = roomRepository.GetRoomTypeByID(int.Parse(txtRoomType.Text)).RoomType;
        }

        private void txtLoad_Click(object sender, EventArgs e)
        {
            LoadRoomList();
        }
    }
}
