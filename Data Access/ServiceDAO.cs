using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class ServiceDAO : BaseDAL
    {
        private static ServiceDAO instance = null;
        private static readonly object instnaceLock = new object();
        private ServiceDAO() { }
        public static ServiceDAO Instance
        {
            get
            {
                lock (instnaceLock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceDAO();
                    }
                    return instance;
                }
            }
        }



        public List<ServiceObject> GetServiceList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select ServiceID, ServiceName, ServicePrice from Service";
            var services = new List<ServiceObject>();
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    services.Add(new ServiceObject
                    {
                        ServiceID = dataReader.GetInt32(0),
                        ServiceName = dataReader.GetString(1),
                        ServicePrice = dataReader.GetDecimal(2),


                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return services;
        }
        public ServiceObject GetServicesByID(int ServiceID)
        {
            ServiceObject service = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select ServiceID, ServiceName, ServicePrice from Service where ServiceID = @ServiceID";
            try
            {
                var param = DataProvider.CreateParameter("@ServiceID", 4, ServiceID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    service = new ServiceObject
                    {
                        ServiceID = dataReader.GetInt32(0),
                        ServiceName = dataReader.GetString(1),
                        ServicePrice = dataReader.GetDecimal(2),
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return service;
        }

        public List<ServiceObject> GetServiceByID(int ServiceID)
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select ServiceID, ServiceName, ServicePrice from Service where ServiceID = @ServiceID";
            var services = new List<ServiceObject>();
            try
            {
                var param = DataProvider.CreateParameter("@ServiceID", 4, ServiceID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                while (dataReader.Read())
                {
                    services.Add(new ServiceObject
                    {
                        ServiceID = dataReader.GetInt32(0),
                        ServiceName = dataReader.GetString(1),
                        ServicePrice = dataReader.GetDecimal(2),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return services;
        }
        //-------------------------------------------------
        //Add new a employee
        public void AddNew(ServiceObject service)
        {
            try
            {
                ServiceObject isEmpty = GetServicesByID(service.ServiceID);
                if (isEmpty == null)
                {
                    string SQLInsert = "Insert Service values(@ServiceID, @ServiceName, @ServicePrice)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@ServiceID", 4, service.ServiceID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ServiceName", 50, service.ServiceName, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@ServicePrice", 50, service.ServicePrice, DbType.Decimal));

                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The service is already exist");
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //-------------------------------------------------
        //Update a employee
        public void Update(ServiceObject service)
        {
            try
            {
                ServiceObject isEmpty = GetServicesByID(service.ServiceID);
                if (isEmpty != null)
                {
                    string SQLInsert = "Update Service set ServiceID = @ServiceID, ServiceName = @ServiceName, ServicePrice = @ServicePrice" +
                        " where ServiceID = @ServiceID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@ServiceID", 4, service.ServiceID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ServiceName", 50, service.ServiceName, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@ServicePrice", 50, service.ServicePrice, DbType.Decimal));

                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The service is already exist.");
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //--------------------------------------------------
        public void Remove(int ServiceID)
        {
            try
            {
                ServiceObject isEmpty = GetServicesByID(ServiceID);
                if (isEmpty != null)
                {
                    string SQLDelete = "Delete Service where ServiceID = @ServiceID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@ServiceID", 4, ServiceID, DbType.Int32));
                    DataProvider.Update(SQLDelete, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The service is already exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


    }
}
