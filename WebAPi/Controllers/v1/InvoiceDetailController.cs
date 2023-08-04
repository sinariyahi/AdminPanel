using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
    
    public class InvoiceDetailController : BaseController
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;

        public InvoiceDetailController(IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(InvoiceDetail invoiceDetail, CancellationToken cancellationToken)
        {
            return Ok(await _invoiceDetailRepository.AddInvoiceDetailAsync(invoiceDetail, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<InvoiceDetail>> Put(InvoiceDetail category, CancellationToken cancellationToken)
        {
            return Ok(await _invoiceDetailRepository.UpdateInvoiceDetailAsync(category, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetail>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _invoiceDetailRepository.FindInvoiceDetailAsync(id, cancellationToken));
        }

    }
}
