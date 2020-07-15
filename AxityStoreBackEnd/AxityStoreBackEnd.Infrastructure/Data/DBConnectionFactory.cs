using Npgsql;
using System.Data;

namespace AxityStoreBackEnd.Infrastructure.Data
{
    public static class DBConnectionFactory
    {
        public static IDbConnection GetConnection(string connectionString)
        {
            IDbConnection connection = new NpgsqlConnection(connectionString);

            if (connection.State != ConnectionState.Closed)
                connection.Open();

            return connection;
        }
    }
}
