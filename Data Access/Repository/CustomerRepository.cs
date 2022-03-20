using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        

        IEnumerable<CustomerObject> ICustomerRepository.GetCustomers() => CustomerDAO.Instance.GetCustomerList();

        CustomerObject ICustomerRepository.GetCustomersByID(int customerID) => CustomerDAO.Instance.GetCustomersByID(customerID);

        public void UpdateCustomer(CustomerObject Customer)
        {
            CustomerDAO.Instance.Update(Customer);
        }

        public IEnumerable<CustomerObject> GetCustomerByID(int customerID) => CustomerDAO.Instance.GetCustomerByID(customerID);


    }
}
