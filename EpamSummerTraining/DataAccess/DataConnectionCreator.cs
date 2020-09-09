using System.Configuration;
using System.Data.SqlClient;

namespace EpamSummerTraining.DataAccess
{
    public class DataConnectionCreator
    {
        private static DataConnectionCreator _instance;
        // private readonly SqlConnection _connection;

        private DataConnectionCreator(string connectionString = "DefaultConnection")
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
        }

        public string ConnectionString { get; private set; }
        public SqlConnection Connection { get; private set; }

        public static DataConnectionCreator GetConnection()
        {
            _instance ??= new DataConnectionCreator();
            return _instance;
        }
    }
}
