using AxityStoreBackEnd.Domain.DTO;
using AxityStoreBackEnd.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTOProduct>>> GetAll() =>
            (await _productService.GetAllAsync()).ToList();
    }
}
