using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{

    public class DiscountController : BaseController
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(Discount category, CancellationToken cancellationToken)
        {
            return Ok(await _discountRepository.AddDiscountAsync(category, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Discount>> Put(Discount category, CancellationToken cancellationToken)
        {
            return Ok(await _discountRepository.UpdateDiscountAsync(category, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _discountRepository.FindDiscountAsync(id, cancellationToken));
        }

    }
}
