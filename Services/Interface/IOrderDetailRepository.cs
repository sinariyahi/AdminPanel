using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken);
        Task<OrderDetail> FindOrderDetailAsync(int id, CancellationToken cancellationToken);
        Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken);

    }
}
