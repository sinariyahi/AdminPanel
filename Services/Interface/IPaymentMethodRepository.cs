using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPaymentMethodRepository
    {
        Task<PaymentMethod> AddPaymentMethodAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken);
        Task<PaymentMethod> FindPaymentMethodAsync(int id, CancellationToken cancellationToken);
        Task<PaymentMethod> UpdatePaymentMethodAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken);

    }
}
