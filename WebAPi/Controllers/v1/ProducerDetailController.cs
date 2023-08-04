using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
    
    public class ProducerDetailController : BaseController
    {
        private readonly IProducerDetailRepository _producerDetailRepository;

        public ProducerDetailController(IProducerDetailRepository producerDetailRepository)
        {
            _producerDetailRepository = producerDetailRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(ProducerDetail producerDetail, CancellationToken cancellationToken)
        {
            return Ok(await _producerDetailRepository.AddProducerDetailAsync(producerDetail, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<ProducerDetail>> Put(ProducerDetail producerDetail, CancellationToken cancellationToken)
        {
            return Ok(await _producerDetailRepository.UpdateProducerDetailAsync(producerDetail, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProducerDetail>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _producerDetailRepository.FindProducerDetailAsync(id, cancellationToken));
        }

    }
}
