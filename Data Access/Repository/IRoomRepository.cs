using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Data_Access.Repository
{
    public interface IRoomRepository
    {
        RoomObject GetRoomByID(int roomID);
        IEnumerable<RoomObject> GetRooms();
        IEnumerable<RoomTypeObject> GetRoomsType();
        RoomTypeObject GetRoomTypeByID(int roomTypeID);
        RoomTypeObject GetRoomTypeByName(string roomTypeName);
        void UpdateRoom(RoomObject room);
    }
}
