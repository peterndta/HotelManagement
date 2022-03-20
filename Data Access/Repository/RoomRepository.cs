using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Data_Access;

namespace Data_Access.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public RoomObject GetRoomByID(int roomID) => RoomDAO.Instance.GetRoomByID(roomID);
        public RoomTypeObject GetRoomTypeByID(int roomTypeID) => RoomDAO.Instance.GetRoomTypeByID(roomTypeID);
        public RoomTypeObject GetRoomTypeByName(string roomTypeName) => RoomDAO.Instance.GetRoomTypeByName(roomTypeName);
        public IEnumerable<RoomObject> GetRooms() => RoomDAO.Instance.GetRoomsList();
        public void UpdateRoom(RoomObject room)=> RoomDAO.Instance.Update(room);

        public IEnumerable<RoomTypeObject> GetRoomsType() => RoomDAO.Instance.GetRoomsTypeList();
    }
}
