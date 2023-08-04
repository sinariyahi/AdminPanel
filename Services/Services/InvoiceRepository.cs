using AutoMapper;
using Domain.Entities;
using InfraStructure;
using InfraStructure.Contracts;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class InvoiceRepository : IBaseSevice , IInvoiceRepository 
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        protected readonly IMapper _mapper;

        public InvoiceRepository(IRepository<Invoice> invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<Invoice> AddInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            await _invoiceRepository.AddAsync(invoice, cancellationToken);
            return invoice;
        }
        public async Task<Invoice> UpdateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken)
        {
            await _invoiceRepository.UpdateAsync(invoice, cancellationToken);
            return invoice;
        }
        public async Task<Invoice> FindInvoiceAsync(int id, CancellationToken cancellationToken)
        {
            var Inv = await _invoiceRepository.GetByIdAsync(cancellationToken, id);
            return Inv;
        }

    }
}
