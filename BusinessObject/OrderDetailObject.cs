using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetailObject
    {
        public int DetailsID { get; set; }
        public int OrderID { get; set; }
        public int ServiceID { get; set; }
        public decimal ServicePrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

    }
}
