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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<PagedList<OrderGridView>> Index(CancellationToken cancellationToken, string name, int pageNumber = 0, int pagesize = 10)
        {
            return await _orderRepository.GetAll(pageNumber, pagesize, name, cancellationToken);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Order>> Post(Order order, CancellationToken cancellationToken)
        {
            return Ok(await _orderRepository.AddOrderAsync(order, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Order>> Put(Order category, CancellationToken cancellationToken)
        {
            return Ok(await _orderRepository.UpdateOrderAsync(category, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _orderRepository.FindOrderAsync(id, cancellationToken));
        }

    }
}

