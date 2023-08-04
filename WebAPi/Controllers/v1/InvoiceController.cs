using AutoMapper;
using Domain.Entities;
using InfraStructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(Invoice invoiceDetail, CancellationToken cancellationToken)
        {
            return Ok(await _invoiceRepository.AddInvoiceAsync(invoiceDetail, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Invoice>> Put(Invoice invoice, CancellationToken cancellationToken)
        {
            return Ok(await _invoiceRepository.UpdateInvoiceAsync(invoice, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _invoiceRepository.FindInvoiceAsync(id, cancellationToken));
        }

    }
}
