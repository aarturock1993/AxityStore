using AxityStoreBackEnd.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
    }
}
