using Domain.Common;
using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebAPi.Controllers.v1
{

    public class CategoryController : BaseController
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        //public async Task<ActionResult<PagedList<CateGoryGridView>>> GetAll(CancellationToken cancellationToken, string name, int pageNumber=0,int pagesize=10)
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken, string name, int pageNumber = 0, int pagesize = 10)
        {
            try
            {
                var result = await _categoriesRepository.GetAll(pageNumber, pagesize, name, cancellationToken);
                //return Ok();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }
        [HttpPost("create")]
        //public  async Task<ActionResult<Category>> Post(Category category, CancellationToken cancellationToken)
        public async Task<IActionResult> Post(Category category, CancellationToken cancellationToken)
        {
            return Ok(await _categoriesRepository.AddCategoryAsync(category, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Category>> Put(Category category, CancellationToken cancellationToken)
        {
            return Ok(await _categoriesRepository.UpdateCategoryAsync(category, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _categoriesRepository.FindCategoryAsync(id, cancellationToken));
        }
      
    }
}
