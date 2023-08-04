using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IShippingMethodRepository
    {
        Task<ShippingMethod> AddShippingMethodAsync(ShippingMethod shippingMethod, CancellationToken cancellationToken);
        Task<ShippingMethod> FindShippingMethodAsync(int id, CancellationToken cancellationToken);
        Task<ShippingMethod> UpdateShippingMethodAsync(ShippingMethod shippingMethod, CancellationToken cancellationToken);

    }
}
