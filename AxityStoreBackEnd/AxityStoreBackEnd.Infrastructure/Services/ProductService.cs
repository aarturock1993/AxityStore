using AutoMapper;
using AxityStoreBackEnd.Domain.DTO;
using AxityStoreBackEnd.Domain.Interfaces;
using AxityStoreBackEnd.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTOProduct>> GetAllAsync()
        {
            IEnumerable<DTOProduct> productsDto = null;

            var result = await _productRepository.GetAll();
            productsDto = _mapper.Map<IEnumerable<DTOProduct>>(result);

            return productsDto;
        }
    }
}
