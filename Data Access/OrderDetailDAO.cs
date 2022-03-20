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
    public class OrderDetailDAO : BaseDAL
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDetailDAO() { }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public OrderDetailObject GetOrderDetailsByID(int orderID)
        {
            OrderDetailObject order = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select DetailsID, OderID, ServiceID, ServicePrice, Quantity, Total from OrderDetail where DetailsID = @DetailsID";
            try
            {
                var param = DataProvider.CreateParameter("@DetailsID", 4, orderID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    order = new OrderDetailObject
                    {
                        DetailsID = dataReader.GetInt32(0),
                        OrderID = dataReader.GetInt32(1),
                        ServiceID = dataReader.GetInt32(2),
                        ServicePrice = dataReader.GetDecimal(3),
                        Quantity = dataReader.GetInt32(4),
                        Total = dataReader.GetDecimal(5),
                        
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
        public void AddNewOrderDetail(OrderDetailObject order)
        {
            try
            {
                OrderDetailObject isEmpty = GetOrderDetailsByID(order.DetailsID);
                if (isEmpty == null)
                {
                    string SQLInsert = "Insert OrderDetail values(@DetailsID, @OderID, @ServiceID, @ServicePrice, @Quantity, @Total)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@DetailsID", 4, order.DetailsID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@OderID", 4, order.OrderID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ServiceID", 4, order.ServiceID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@ServicePrice", 50, order.ServicePrice, DbType.Decimal));
                    parameters.Add(DataProvider.CreateParameter("@Quantity", 4, order.Quantity, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@Total", 50, order.Total, DbType.Decimal));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Order Detail ID is already exist");
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

        public List<OrderDetailObject> GetDetailsList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select DetailsID from OrderDetail";
            var details = new List<OrderDetailObject>();
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    details.Add(new OrderDetailObject
                    {
                        DetailsID = dataReader.GetInt32(0),
                        //OrderID = dataReader.GetInt32(1),
                        //ServiceID = dataReader.GetInt32(2),
                        //ServicePrice = dataReader.GetDecimal(3),
                        //Quantity = dataReader.GetInt32(4),
                        //Total = dataReader.GetDecimal(5),

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
            return details;
        }

        public List<OrderDetailObject> GetDetailsByOrderID(int orderID)
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select DetailsID, OderID, ServiceID, ServicePrice, Quantity, Total from OrderDetail where OderID = @OderID";
            var details = new List<OrderDetailObject>();
            try
            {
                var param = DataProvider.CreateParameter("@OderID", 4, orderID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                while (dataReader.Read())
                {
                    details.Add(new OrderDetailObject
                    {
                        DetailsID = dataReader.GetInt32(0),
                        OrderID = dataReader.GetInt32(1),
                        ServiceID = dataReader.GetInt32(2),
                        ServicePrice = dataReader.GetDecimal(3),
                        Quantity = dataReader.GetInt32(4),
                        Total = dataReader.GetDecimal(5),

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
            return details;
        }

        public void Remove(int orderDetailID)
        {
            try
            {
                OrderDetailObject isEmpty = GetOrderDetailsByID(orderDetailID);
                if (isEmpty != null)
                {
                    string SQLDelete = "Delete OrderDetail where DetailsID = @DetailsID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@DetailsID", 4, orderDetailID, DbType.Int32));
                    DataProvider.Update(SQLDelete, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The employee is already exist.");
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
