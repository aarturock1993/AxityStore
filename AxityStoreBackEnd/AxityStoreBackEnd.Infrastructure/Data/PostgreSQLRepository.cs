using AxityStoreBackEnd.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System.Data;

namespace AxityStoreBackEnd.Infrastructure.Data
{
    public abstract class PostgreSQLRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public PostgreSQLRepository(IOptions<ConfigurationApp> options)
        {
            _connectionString = options.Value.ConnectionDatabase;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State == ConnectionState.Closed)
                _connection = DBConnectionFactory.GetConnection(_connectionString);

            return _connection;
        }
    }
}
