using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public interface ICustomerRepository
    {
      
        CustomerObject GetCustomersByID(int customerID);

        IEnumerable<CustomerObject> GetCustomerByID(int customerID);
        IEnumerable<CustomerObject> GetCustomers();       
        
        void UpdateCustomer(CustomerObject Customer);
    }
}
