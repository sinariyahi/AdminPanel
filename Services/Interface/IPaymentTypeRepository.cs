using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPaymentTypeRepository
    {
        Task<PaymentType> AddPaymentTypeAsync(PaymentType paymentType, CancellationToken cancellationToken);
        Task<PaymentType> FindPaymentTypeAsync(int id, CancellationToken cancellationToken);
        Task<PaymentType> UpdatePaymentTypeAsync(PaymentType paymentType, CancellationToken cancellationToken);

    }
}
