using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;


namespace Data_Access
{
    public class EmployeeDAO : BaseDAL
    {
        private static EmployeeDAO instance = null;
        private static readonly object instnaceLock = new object();
        private EmployeeDAO() { }
        public static EmployeeDAO Instance
        {
            get
            {
                lock (instnaceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDAO();
                    }
                    return instance;
                }
            }
        }
        public EmployeeObject Login(string username, string password)
        {
            EmployeeObject employee = null;
            IDataReader dataReader = null;
            try
            {
                string SQLSelect = "Select EmployeeID, EmployeeName, PathImage, username, password from Employee where username = @username AND password=@password";
                var parameters = new List<SqlParameter>();
                parameters.Add(DataProvider.CreateParameter("@username", 50, username, DbType.String));
                parameters.Add(DataProvider.CreateParameter("@password", 30, password, DbType.String));
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameters.ToArray());

                if (dataReader.Read())
                {
                    employee = new EmployeeObject
                    {
                        EmployeeID = dataReader.GetInt32(0),
                        EmployeeName = dataReader.GetString(1),
                        PathImage = dataReader.GetString(2),
                        username = dataReader.GetString(3),
                        password = dataReader.GetString(4),
                    };
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
            return employee;
        }

        //-----------------------------------------------------------------------
        public List<EmployeeObject> GetEmloyeeList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select EmployeeID, EmployeeName, PathImage, username, password from Employee";
            var employees = new List<EmployeeObject>();
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    employees.Add(new EmployeeObject
                    {
                        EmployeeID = dataReader.GetInt32(0),
                        EmployeeName = dataReader.GetString(1),
                        PathImage = dataReader.GetString(2),
                        username = dataReader.GetString(3),
                        password = dataReader.GetString(4),

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
            return employees;
        }
        public EmployeeObject GetEmployeeByID(int EmployeeID)
        {
            EmployeeObject employee = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select EmployeeID, EmployeeName, PathImage, username, password from Employee where EmployeeID = @EmployeeID";
            try
            {
                var param = DataProvider.CreateParameter("@EmployeeID", 4, EmployeeID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    employee = new EmployeeObject
                    {
                        EmployeeID = dataReader.GetInt32(0),
                        EmployeeName = dataReader.GetString(1),
                        PathImage = dataReader.GetString(2),
                        username = dataReader.GetString(3),
                        password = dataReader.GetString(4),
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
            return employee;
        }

        public List<EmployeeObject> GetEmployeesByID(int employeeID)
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select EmployeeID, EmployeeName, PathImage, username, password from Employee where EmployeeID = @EmployeeID";
            var employees = new List<EmployeeObject>();
            try
            {
                var param = DataProvider.CreateParameter("@EmployeeID", 4, employeeID, DbType.Int32);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                while (dataReader.Read())
                {
                    employees.Add(new EmployeeObject
                    {
                        EmployeeID = dataReader.GetInt32(0),
                        EmployeeName = dataReader.GetString(1),
                        PathImage = dataReader.GetString(2),
                        username = dataReader.GetString(3),
                        password = dataReader.GetString(4),
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
            return employees;
        }
        //-------------------------------------------------
        //Add new a employee
        public void AddNew(EmployeeObject employee)
        {
            try
            {
                EmployeeObject isEmpty = GetEmployeeByID(employee.EmployeeID);
                if (isEmpty == null)
                {
                    string SQLInsert = "Insert Employee values(@EmployeeID, @EmployeeName, @PathImage, @username, @password)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@EmployeeID", 4, employee.EmployeeID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@EmployeeName", 50, employee.EmployeeName, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@PathImage", 1000, employee.PathImage, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@username", 50, employee.username, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@password", 30, employee.password, DbType.String));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The employee is already exist");
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
        public void Update(EmployeeObject employee)
        {
            try
            {
                EmployeeObject isEmpty = GetEmployeeByID(employee.EmployeeID);
                if (isEmpty != null)
                {
                    string SQLInsert = "Update Employee set EmployeeID = @EmployeeID, EmployeeName = @EmployeeName, PathImage = @PathImage, username = @username, password = @password" +
                        " where EmployeeID = @EmployeeID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@EmployeeID", 4, employee.EmployeeID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@EmployeeName", 50, employee.EmployeeName, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@PathImage", 1000, employee.PathImage, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@username", 50, employee.username, DbType.String));
                    parameters.Add(DataProvider.CreateParameter("@password", 30, employee.password, DbType.String));
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
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
        //--------------------------------------------------
        public void Remove(int employeeID)
        {
            try
            {
                EmployeeObject isEmpty = GetEmployeeByID(employeeID);
                if (isEmpty != null)
                {
                    string SQLDelete = "Delete Employee where EmployeeID = @EmployeeID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@EmployeeID", 4, employeeID, DbType.Int32));
                    DataProvider.Update(SQLDelete, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The Serivice does not already exist.");
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
