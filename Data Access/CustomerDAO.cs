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
    public class CustomerDAO : BaseDAL
    {
        private static CustomerDAO instance = null;
        private static readonly object instnaceLock = new object();
        private CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instnaceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        //-----------------------------------------------------------------------
        public List<CustomerObject> GetCustomerList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select CustomerID, NameCustomer, Nationality from Customer";
            var customers = new List<CustomerObject>();
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    customers.Add(new CustomerObject
                    {
                        CustomerID = dataReader.GetInt32(0),
                        NameCustomer = dataReader.GetString(1),
                        Nationality = dataReader.GetString(2),
                 
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
            return customers;
        }
        public CustomerObject GetCustomersByID(int CustomerID)
        {
            CustomerObject customer = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select CustomerID, NameCustomer, Nationality from Customer where CustomerID = @CustomerID";
            try
            {
                var param = DataProvider.CreateParameter("@CustomerID", 4, CustomerID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    customer = new CustomerObject
                    {
                        CustomerID = dataReader.GetInt32(0),
                        NameCustomer = dataReader.GetString(1),
                        Nationality = dataReader.GetString(2),
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
            return customer;
        }
        public List<CustomerObject> GetCustomerByID(int CustomerID)
        {
            var customer = new List<CustomerObject>();
            IDataReader dataReader = null;
            string SQLSelect = "Select CustomerID, NameCustomer, Nationality from Customer where CustomerID = @CustomerID";
            try
            {
                var param = DataProvider.CreateParameter("@CustomerID", 4, CustomerID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    customer.Add( new CustomerObject
                    {
                        CustomerID = dataReader.GetInt32(0),
                        NameCustomer = dataReader.GetString(1),
                        Nationality = dataReader.GetString(2),
                    } );

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
            return customer;
        }

        public void Update(CustomerObject customer)
        {
            try
            {
                CustomerObject isEmpty = GetCustomersByID(customer.CustomerID);
                if (isEmpty != null)
                {
                    string SQLInsert = "Update Customer set CustomerID = @CustomerID, NameCustomer = @NameCustomer, Nationality = @Nationality" +
                        " where CustomerID = @CustomerID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@CustomerID", 4, customer.CustomerID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@CustomerName", 50, customer.NameCustomer, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@Nationality", 50, customer.Nationality, DbType.String));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The customer is already exist.");
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


