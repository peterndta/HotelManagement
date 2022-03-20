using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public interface IOrderRepository
    {
        RoomObject GetRoomByID(int roomID);
        RoomTypeObject GetRoomTypeByID(int roomTypeID);
        OrderObject GetOrderByID(int orderID);
        CustomerObject GetCustomerByID(int customerID);
        void InsertOrder(OrderObject order);
        void InsertCustomer(CustomerObject customer);
        IEnumerable<OrderObject> GetOrderList();
    }
}
