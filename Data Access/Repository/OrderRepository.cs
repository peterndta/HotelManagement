using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public RoomObject GetRoomByID(int roomID) => OrderDAO.Instance.GetRoomByID(roomID);

        public RoomTypeObject GetRoomTypeByID(int roomTypeID) => OrderDAO.Instance.GetRoomTypeByID(roomTypeID);   

        public OrderObject GetOrderByID(int orderID) => OrderDAO.Instance.GetOrderByID(orderID);

        public CustomerObject GetCustomerByID(int customerID) => OrderDAO.Instance.GetCustomerByID(customerID);

        public void InsertCustomer(CustomerObject customer) => OrderDAO.Instance.AddNewCustomer(customer);

        public void InsertOrder(OrderObject order) => OrderDAO.Instance.AddNewOrder(order);

        public IEnumerable<OrderObject> GetOrderList() => OrderDAO.Instance.GetOrderList();
    }
}
