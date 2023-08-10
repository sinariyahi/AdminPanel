using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebAPi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoriesRepository _subcategoriesRepository;
        private readonly IProducerRepository _producerRepository;
        private ISubcategoriesRepository @object;

        public SubcategoryController(ISubcategoriesRepository subcategoriesRepository, IProducerRepository producerRepository)
        {
            _subcategoriesRepository = subcategoriesRepository;
            _producerRepository = producerRepository;
        }

        public SubcategoryController(ISubcategoriesRepository @object)
        {
            this.@object = @object;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Subcategory>> Post(Subcategory subcategory, CancellationToken cancellationToken)
        {
            return Ok(await _subcategoriesRepository.AddSubcategoryAsync(subcategory, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Subcategory>> Put(Subcategory subcategory, CancellationToken cancellationToken)
        {
            return Ok(await _subcategoriesRepository.UpdateSubcategoryAsync(subcategory, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategory>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _subcategoriesRepository.FindSubcategoryAsync(id, cancellationToken));
        }

    }
}

