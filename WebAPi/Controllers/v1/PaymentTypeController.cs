using AutoMapper;
using Domain.Entities;
using InfraStructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{

    public class PaymentTypeController : BaseController
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public PaymentTypeController(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(PaymentType paymentType, CancellationToken cancellationToken)
        {
            return Ok(await _paymentTypeRepository.AddPaymentTypeAsync(paymentType, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<PaymentType>> Put(PaymentType paymentType, CancellationToken cancellationToken)
        {
            return Ok(await _paymentTypeRepository.UpdatePaymentTypeAsync(paymentType, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _paymentTypeRepository.FindPaymentTypeAsync(id, cancellationToken));
        }

    }
}
