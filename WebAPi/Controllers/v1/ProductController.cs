using Domain.Common;
using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebAPi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<PagedList<ProductGridView>> Index(CancellationToken cancellationToken, string name, int pageNumber = 0, int pagesize = 10)
        {
            return await _productRepository.GetAll(pageNumber, pagesize, name, cancellationToken);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Product>> Post(Product order, CancellationToken cancellationToken)
        {
            return Ok(await _productRepository.AddProductAsync(order, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Product>> Put(Product category, CancellationToken cancellationToken)
        {
            return Ok(await _productRepository.UpdateProductAsync(category, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _productRepository.FindProductAsync(id, cancellationToken));
        }
    }
}

