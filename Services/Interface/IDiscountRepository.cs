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
    public interface IDiscountRepository
    {
        Task<Discount> AddDiscountAsync(Discount discount, CancellationToken cancellationToken);
        Task<Discount> FindDiscountAsync(int id, CancellationToken cancellationToken);
        Task<Discount> UpdateDiscountAsync(Discount discount, CancellationToken cancellationToken);

    }
}
