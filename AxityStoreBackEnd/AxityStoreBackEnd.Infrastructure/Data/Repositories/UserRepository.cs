using AxityStoreBackEnd.Domain.Entities;
using AxityStoreBackEnd.Domain.Interfaces;
using AxityStoreBackEnd.Infrastructure.Configuration;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Infrastructure.Data.Repositories
{
    public class UserRepository : PostgreSQLRepository, IUserRepository
    {
        public UserRepository(IOptions<ConfigurationApp> options): base(options) {}
        public async Task<User> Login(string name, string lastName)
        {
            User userEntity = null;

            using (var connection = GetOpenConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DX_NAME", name.Trim());
                parameters.Add("@DX_LASTNAME", lastName.Trim());

                userEntity = await connection.QueryFirstOrDefaultAsync<User>
                    ("SELECT * FROM \"Usuario\" WHERE \"Nombre\" = @DX_NAME and \"Apellido\" = @DX_LASTNAME", parameters, commandType: CommandType.Text);

                connection.Close();
            }
            return userEntity;
        }
    }
}
