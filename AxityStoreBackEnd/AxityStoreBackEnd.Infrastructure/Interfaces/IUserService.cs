using AxityStoreBackEnd.Domain.DTO;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<DTOUser> Login(string name, string lastName);
    }
}
