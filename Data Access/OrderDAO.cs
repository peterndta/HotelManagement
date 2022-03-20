using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data_Access
{
    public class OrderDAO : BaseDAL
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public OrderObject GetOrderByID(int orderID)
        {
            OrderObject order = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select OrderID, EmployeeID, CustomerID, RoomID, RoomType, CheckInDay, NumberOfCustomer, OrderDay, Total from [Order] where OrderID = @OrderID";
            try
            {
                var param = DataProvider.CreateParameter("@OrderID", 4, orderID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new OrderObject
                    {
                        OrderID = dataReader.GetInt32(0),
                        EmployeeID = dataReader.GetInt32(1),
                        CustomerID = dataReader.GetInt32(2),
                        RoomID = dataReader.GetInt32(3),
                        RoomType = dataReader.GetString(4),
                        CheckInDay = dataReader.GetDateTime(5),
                        NumberOfCustomer = dataReader.GetInt32(6),
                        OrderDay = dataReader.GetDateTime(7),
                        Total = dataReader.GetDecimal(8),
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
            return order;
        }
        public CustomerObject GetCustomerByID(int customerID)
        {
            CustomerObject customer = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select CustomerID, NameCustomer, Nationality from Customer where CustomerID = @CustomerID";
            try
            {
                var param = DataProvider.CreateParameter("@CustomerID", 4, customerID, DbType.Int32);
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
        public void AddNewOrder(OrderObject order)
        {
            try
            {
                OrderObject isEmpty = GetOrderByID(order.OrderID);
                if (isEmpty == null)
                {
                    string SQLInsert = "Insert [Order] values(@OrderId, @EmployeeID, @CustomerID, @RoomID, @RoomType, @CheckInDay, @NumberOfCustomer, @OrderDay, @Total)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@OrderID", 4, order.OrderID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@EmployeeID", 4, order.EmployeeID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@CustomerID", 4, order.CustomerID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@RoomID", 4, order.RoomID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@RoomType", 15, order.RoomType, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@CheckInDay", 50, order.CheckInDay, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@NumberOfCustomer", 30, order.NumberOfCustomer, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@OrderDay", 50, order.OrderDay, DbType.DateTime));
                    parameters.Add(DataProvider.CreateParameter("@Total", 50, order.Total, DbType.Decimal));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Order ID is already exist");
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

        public void AddNewCustomer(CustomerObject customer)
        {
            try
            {
                CustomerObject isEmpty = GetCustomerByID(customer.CustomerID);
                if (isEmpty == null)
                {
                    string SQLInsert = "Insert Customer values(@CustomerID, @NameCustomer, @Nationality)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@CustomerID", 4, customer.CustomerID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@NameCustomer", 50, customer.NameCustomer, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@Nationality", 50, customer.Nationality, DbType.String));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Customer ID is already exist");
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

        public RoomObject GetRoomByID(int roomID)
        {
            RoomObject room = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select RoomID, RoomTypeID, RoomPrice from Room where RoomID = @RoomID";
            try
            {
                var param = DataProvider.CreateParameter("@RoomID", 4, roomID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    room = new RoomObject
                    {
                        RoomID = dataReader.GetInt32(0),
                        RoomTypeID = dataReader.GetInt32(1),
                        RoomPrice = dataReader.GetDecimal(2),
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
            return room;
        }

        public RoomTypeObject GetRoomTypeByID(int roomTypeID)
        {
            RoomTypeObject roomType = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select RoomTypeID, RoomType from RoomType where RoomTypeID = @RoomTypeID";
            try
            {
                var param = DataProvider.CreateParameter("@RoomTypeID", 4, roomTypeID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    roomType = new RoomTypeObject
                    {
                        RoomTypeID = dataReader.GetInt32(0),
                        RoomType = dataReader.GetString(1),
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
            return roomType;
        }

        public List<OrderObject> GetOrderList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select OrderID, CustomerID from [Order]";
            var orders = new List<OrderObject>();
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    orders.Add(new OrderObject
                    {
                        OrderID = dataReader.GetInt32(0),
                        CustomerID = dataReader.GetInt32(1),

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
            return orders;
        }

    }
}
