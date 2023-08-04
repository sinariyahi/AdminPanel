using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IInvoiceRepository
    {
        Task<Invoice> AddInvoiceAsync(Invoice invoice, CancellationToken cancellationToken);
        Task<Invoice> FindInvoiceAsync(int id, CancellationToken cancellationToken);
        Task<Invoice> UpdateInvoiceAsync(Invoice invoice, CancellationToken cancellationToken);

    }
}
