using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Data_Access
{
    public class BaseDAL
    {
        public StockDataProvider DataProvider { get; set; } = null;
        public SqlConnection connection = null;
        //------------------------------------------
        public BaseDAL()
        {
            var connectionString = GetConnectionString();
            DataProvider = new StockDataProvider(connectionString);
        }
        //------------------------------------------
        public string GetConnectionString()
        {
            string connectionString;

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            connectionString = config["ConnectionString:MyStockDB"];
            return connectionString;
        }
        //-------------------------------------------
        public void CloseConnection() => DataProvider.CloseConnection(connection);
    }//------------------END-------------------------
}
