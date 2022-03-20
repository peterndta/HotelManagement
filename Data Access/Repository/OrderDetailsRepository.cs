using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        public void InsertOrderDetail(OrderDetailObject orderDetail) => OrderDetailDAO.Instance.AddNewOrderDetail(orderDetail);

        public OrderDetailObject GetOrderDetailsByID(int orderDetailID) => OrderDetailDAO.Instance.GetOrderDetailsByID(orderDetailID);

        public IEnumerable<OrderDetailObject> GetOrderDetail() => OrderDetailDAO.Instance.GetDetailsList();
        public IEnumerable<OrderDetailObject> GetDetailsByOrderID(int orderID) => OrderDetailDAO.Instance.GetDetailsByOrderID(orderID);

        public void DeleteOrderService(int orderDetailID) => OrderDetailDAO.Instance.Remove(orderDetailID);
    }
}
