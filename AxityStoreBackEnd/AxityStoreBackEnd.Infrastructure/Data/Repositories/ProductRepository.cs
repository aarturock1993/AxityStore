using AxityStoreBackEnd.Domain.Entities;
using AxityStoreBackEnd.Domain.Interfaces;
using AxityStoreBackEnd.Infrastructure.Configuration;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Infrastructure.Data.Repositories
{
    public class ProductRepository : PostgreSQLRepository, IProductRepository
    {
        public ProductRepository(IOptions<ConfigurationApp> options): base(options) { }

        public async Task<IEnumerable<Product>> GetAll()
        {
            IEnumerable<Product> _products = null;

            using (var connection = GetOpenConnection())
            {
                _products = await SqlMapper.QueryAsync<Product>
                    (connection, "SELECT * FROM \"Producto\"", commandType: CommandType.Text);

                connection.Close();
            }

            return _products;
        }
    }
}
