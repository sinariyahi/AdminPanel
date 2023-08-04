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
    public class DiscountRepository : IBaseSevice , IDiscountRepository
    {
        private readonly IRepository<Discount> _discountRepository;
        protected readonly IMapper _mapper;

        public DiscountRepository(IRepository<Discount> discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<Discount> AddDiscountAsync(Discount discount, CancellationToken cancellationToken)
        {
            await _discountRepository.AddAsync(discount, cancellationToken);
            return discount;
        }
        public async Task<Discount> UpdateDiscountAsync(Discount discount, CancellationToken cancellationToken)
        {
            await _discountRepository.UpdateAsync(discount, cancellationToken);
            return discount;
        }
        public async Task<Discount> FindDiscountAsync(int id, CancellationToken cancellationToken)
        {
            var dis = await _discountRepository.GetByIdAsync(cancellationToken, id);
            return dis;
        }

    }
}
