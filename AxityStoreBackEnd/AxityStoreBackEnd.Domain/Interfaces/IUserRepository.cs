using AxityStoreBackEnd.Domain.Entities;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Login(string name, string lastName);
    }
}
