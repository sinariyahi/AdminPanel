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
    public class InvoiceDetailRepository : IBaseSevice , IInvoiceDetailRepository
    {
        private readonly IRepository<InvoiceDetail> _invoiceDetailRepository;
        protected readonly IMapper _mapper;

        public InvoiceDetailRepository(IRepository<InvoiceDetail> invoiceDetailRepository, IMapper mapper)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
            _mapper = mapper;
        }
        public async Task<InvoiceDetail> AddInvoiceDetailAsync(InvoiceDetail invoiceDetail, CancellationToken cancellationToken)
        {
            await _invoiceDetailRepository.AddAsync(invoiceDetail, cancellationToken);
            return invoiceDetail;
        }
        public async Task<InvoiceDetail> UpdateInvoiceDetailAsync(InvoiceDetail invoiceDetail, CancellationToken cancellationToken)
        {
            await _invoiceDetailRepository.UpdateAsync(invoiceDetail, cancellationToken);
            return invoiceDetail;
        }
        public async Task<InvoiceDetail> FindInvoiceDetailAsync(int id, CancellationToken cancellationToken)
        {
            var Inv = await _invoiceDetailRepository.GetByIdAsync(cancellationToken, id);
            return Inv;
        }

    }
}
