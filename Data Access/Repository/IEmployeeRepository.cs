using BusinessObject;
using System.Collections.Generic;

namespace Data_Access.Repository
{
    public interface IEmployeeRepository
    {
        EmployeeObject Login(string username, string password);
        IEnumerable<EmployeeObject> GetEmployeesByID(int employeeID);
        IEnumerable<EmployeeObject> GetEmployees();
        void InsertEmployee(EmployeeObject employee);
        void DeleteEmployee(int employeeID);
        void UpdateEmployee(EmployeeObject employee);
    }
}
