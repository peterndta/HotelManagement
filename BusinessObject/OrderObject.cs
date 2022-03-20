using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderObject
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDay { get; set; }
        public int NumberOfCustomer { get; set; }
        public DateTime OrderDay { get; set; }
        public decimal Total { get; set; }
    }
}
