using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Data_Access.Repository
{
    public interface IServiceRepository
    {
        ServiceObject GetServicesByID(int ServiceID);
        IEnumerable<ServiceObject> GetServices();
        void InsertService(ServiceObject Serivce);
        void DeleteService(int ServiceID);
        void UpdateService(ServiceObject Serivce);
    }
    }