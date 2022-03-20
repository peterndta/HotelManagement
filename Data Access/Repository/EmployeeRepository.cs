using BusinessObject;
using System.Collections.Generic;

namespace Data_Access.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeObject Login(string username, string password) => EmployeeDAO.Instance.Login(username, password);
        IEnumerable<EmployeeObject> IEmployeeRepository.GetEmployees() => EmployeeDAO.Instance.GetEmloyeeList();
        void IEmployeeRepository.InsertEmployee(EmployeeObject Employee)
        {
            EmployeeDAO.Instance.AddNew(Employee);
        }

        void IEmployeeRepository.DeleteEmployee(int EmployeeId)
        {
            EmployeeDAO.Instance.Remove(EmployeeId);
        }

        void IEmployeeRepository.UpdateEmployee(EmployeeObject Employee)
        {
            EmployeeDAO.Instance.Update(Employee);
        }
        IEnumerable<EmployeeObject> IEmployeeRepository.GetEmployeesByID(int employeeID) => EmployeeDAO.Instance.GetEmployeesByID(employeeID);

    }
}
