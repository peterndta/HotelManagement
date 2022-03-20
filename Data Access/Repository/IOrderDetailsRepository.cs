using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public interface IOrderDetailsRepository
    {
        OrderDetailObject GetOrderDetailsByID(int orderDetailID);
        void InsertOrderDetail(OrderDetailObject orderDetail);
        IEnumerable<OrderDetailObject> GetOrderDetail();
        IEnumerable<OrderDetailObject> GetDetailsByOrderID(int orderID);
        void DeleteOrderService(int orderDetailID);
    }
}
