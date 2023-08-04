using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IInvoiceDetailRepository
    {
        Task<InvoiceDetail> AddInvoiceDetailAsync(InvoiceDetail invoiceDetail, CancellationToken cancellationToken);
        Task<InvoiceDetail> FindInvoiceDetailAsync(int id, CancellationToken cancellationToken);
        Task<InvoiceDetail> UpdateInvoiceDetailAsync(InvoiceDetail invoiceDetail, CancellationToken cancellationToken);

    }
}
