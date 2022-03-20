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
    public partial class frmRoomType : Form
    {
        public frmRoomType()
        {
            InitializeComponent();
        }

        public IRoomRepository RoomRepository = new RoomRepository();
        public RoomObject RoomInfo { get; set; }
        private void frmRoomType_Load(object sender, EventArgs e)
        {
            var type = RoomInfo.RoomTypeID;
            comboBox1.Text = RoomInfo.RoomID.ToString();
            txtPrice.Text = RoomInfo.RoomPrice.ToString();
            List<RoomTypeObject> listTypes = null;

            listTypes = RoomRepository.GetRoomsType().ToList<RoomTypeObject>();
            listTypes.ForEach(types => cbRoomType.Items.Add(types.RoomType));
            cbRoomType.SelectedIndex = type - 1;
            cbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
             
                var room = new RoomObject
                {
                    RoomID = int.Parse(comboBox1.Text),
                    RoomTypeID = cbRoomType.SelectedIndex + 1,
                    RoomPrice = Decimal.Parse(txtPrice.Text),
                };

                RoomRepository.UpdateRoom(room);
                MessageBox.Show("Update Success!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Change Type");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
