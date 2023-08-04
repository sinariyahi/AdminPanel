using Domain.Common;
using Domain.Entities;
using Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IOrderRepository
    {
        Task<PagedList<OrderGridView>> GetAll(int pageNumber, int pageSize, string name, CancellationToken cancellationToken);
        Task<Order> AddOrderAsync(Order order, CancellationToken cancellationToken);
        Task<Order> FindOrderAsync(int id, CancellationToken cancellationToken);
        Task<Order> UpdateOrderAsync(Order order, CancellationToken cancellationToken);
    }
}
