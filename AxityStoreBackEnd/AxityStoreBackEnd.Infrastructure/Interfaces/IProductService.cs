using AxityStoreBackEnd.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<DTOProduct>> GetAllAsync();
    }
}
