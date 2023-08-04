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
    public class ShippingMethodRepository : IBaseSevice , IShippingMethodRepository
    {
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        protected readonly IMapper _mapper;

        public ShippingMethodRepository(IRepository<ShippingMethod> shippingMethodRepository, IMapper mapper)
        {
            _shippingMethodRepository = shippingMethodRepository;
            _mapper = mapper;
        }
        public async Task<ShippingMethod> AddShippingMethodAsync(ShippingMethod shippingMethod, CancellationToken cancellationToken)
        {
            await _shippingMethodRepository.AddAsync(shippingMethod, cancellationToken);
            return shippingMethod;
        }
        public async Task<ShippingMethod> UpdateShippingMethodAsync(ShippingMethod shippingMethod, CancellationToken cancellationToken)
        {
            await _shippingMethodRepository.UpdateAsync(shippingMethod, cancellationToken);
            return shippingMethod;
        }
        public async Task<ShippingMethod> FindShippingMethodAsync(int id, CancellationToken cancellationToken)
        {
            var shi = await _shippingMethodRepository.GetByIdAsync(cancellationToken, id);
            return shi;
        }

    }
}
