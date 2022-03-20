using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Data_Access;

namespace Data_Access.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public void DeleteService(int ServiceID)
        {
            ServiceDAO.Instance.Remove(ServiceID);
        }

        IEnumerable<ServiceObject> IServiceRepository.GetServices() => ServiceDAO.Instance.GetServiceList();

        ServiceObject IServiceRepository.GetServicesByID(int ServiceID) => ServiceDAO.Instance.GetServicesByID(ServiceID);

        public void InsertService(ServiceObject Serivce) => ServiceDAO.Instance.AddNew(Serivce);

        public void UpdateService(ServiceObject Serivce)
        {
            ServiceDAO.Instance.Update(Serivce);
        }
    }
}