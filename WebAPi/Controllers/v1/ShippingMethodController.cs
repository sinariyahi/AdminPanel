using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
    public class ShippingMethodController : BaseController
    {
        private readonly IShippingMethodRepository _shippingMethodRepository;

        public ShippingMethodController(IShippingMethodRepository shippingMethodRepository)
        {
            _shippingMethodRepository = shippingMethodRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(ShippingMethod shippingMethod, CancellationToken cancellationToken)
        {
            return Ok(await _shippingMethodRepository.AddShippingMethodAsync(shippingMethod, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<ShippingMethod>> Put(ShippingMethod shippingMethod, CancellationToken cancellationToken)
        {
            return Ok(await _shippingMethodRepository.UpdateShippingMethodAsync(shippingMethod, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingMethod>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _shippingMethodRepository.FindShippingMethodAsync(id, cancellationToken));
        }

    }
}
