using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
    
    public class OrderDetailController : BaseController
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(OrderDetail orderDetail, CancellationToken cancellationToken)
        {
            return Ok(await _orderDetailRepository.AddOrderDetailAsync(orderDetail, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<OrderDetail>> Put(OrderDetail orderDetail, CancellationToken cancellationToken)
        {
            return Ok(await _orderDetailRepository.UpdateOrderDetailAsync(orderDetail, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _orderDetailRepository.FindOrderDetailAsync(id, cancellationToken));
        }

    }
}
