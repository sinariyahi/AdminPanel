using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
  
    public class ProducerController : BaseController
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(Producer producer, CancellationToken cancellationToken)
        {
            return Ok(await _producerRepository.AddProducerAsync(producer, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Producer>> Put(Producer producer, CancellationToken cancellationToken)
        {
            return Ok(await _producerRepository.UpdateProducerAsync(producer, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Producer>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _producerRepository.FindProducerAsync(id, cancellationToken));
        }


    }
}
