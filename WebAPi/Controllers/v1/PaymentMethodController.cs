using AutoMapper;
using Domain.Entities;
using InfraStructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
 
    public class PaymentMethodController : BaseController
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Post(PaymentMethod paymentMethod, CancellationToken cancellationToken)
        {
            return Ok(await _paymentMethodRepository.AddPaymentMethodAsync(paymentMethod, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<PaymentMethod>> Put(PaymentMethod paymentMethod, CancellationToken cancellationToken)
        {
            return Ok(await _paymentMethodRepository.UpdatePaymentMethodAsync(paymentMethod, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _paymentMethodRepository.FindPaymentMethodAsync(id, cancellationToken));
        }

    }
}
