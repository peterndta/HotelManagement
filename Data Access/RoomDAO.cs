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
    public class RoomDAO : BaseDAL
    {
        private static RoomDAO instance = null;
        private static readonly object instnaceLock = new object();
        private RoomDAO() { }
        public static RoomDAO Instance
        {
            get
            {
                lock (instnaceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<RoomObject> GetRoomsList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select RoomID, RoomTypeID, RoomPrice from Room";
            var rooms = new List<RoomObject>();
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    rooms.Add(new RoomObject {
                        RoomID = dataReader.GetInt32(0),
                        RoomTypeID = dataReader.GetInt32(1),
                        RoomPrice = dataReader.GetDecimal(2)
                    });
                }
            }
            catch (Exception ex){ throw new Exception(ex.Message); }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return rooms;
        }

        public IEnumerable<RoomTypeObject> GetRoomsTypeList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select RoomTypeID, RoomType from RoomType";
            var rooms = new List<RoomTypeObject>();
            try
            {
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    rooms.Add(new RoomTypeObject
                    {
                        RoomTypeID = dataReader.GetInt32(0),
                        RoomType = dataReader.GetString(1),
                    });
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return rooms;
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
                        RoomPrice = dataReader.GetDecimal(2)
                    };
                }
            }catch(Exception ex)
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

        public void Update(RoomObject room)
        {
            try
            {
                RoomObject pro = GetRoomByID(room.RoomID);
                if (pro != null)
                {
                    string SQLUpdate = "Update Room set RoomTypeID = @RoomTypeID, RoomPrice = @RoomPrice where RoomID = @RoomID";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(DataProvider.CreateParameter("@RoomID", 4, room.RoomID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@RoomTypeID", 4, room.RoomTypeID, DbType.Int32));
                    parameters.Add(DataProvider.CreateParameter("@RoomPrice", 50, room.RoomPrice, DbType.Decimal));
                    DataProvider.Insert(SQLUpdate, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The room does not already exist!.");
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
                        RoomType = dataReader.GetString(1)
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
        public RoomTypeObject GetRoomTypeByName(string roomTypeName)
        {
            RoomTypeObject roomType = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select RoomTypeID, RoomType from RoomType where RoomType = @RoomType";
            try
            {
                var param = DataProvider.CreateParameter("@RoomType", 15, roomTypeName, DbType.String);
                dataReader = DataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    roomType = new RoomTypeObject
                    {
                        RoomTypeID = dataReader.GetInt32(0),
                        RoomType = dataReader.GetString(1)
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
    }
}
