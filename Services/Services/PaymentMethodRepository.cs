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
    public class PaymentMethodRepository : IBaseSevice , IPaymentMethodRepository 
    {
        private readonly IRepository<PaymentMethod> _paymentMethodRepository;
        protected readonly IMapper _mapper;

        public PaymentMethodRepository(IRepository<PaymentMethod> paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }
        public async Task<PaymentMethod> AddPaymentMethodAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken)
        {
            await _paymentMethodRepository.AddAsync(paymentMethod, cancellationToken);
            return paymentMethod;
        }
        public async Task<PaymentMethod> UpdatePaymentMethodAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken)
        {
            await _paymentMethodRepository.UpdateAsync(paymentMethod, cancellationToken);
            return paymentMethod;
        }
        public async Task<PaymentMethod> FindPaymentMethodAsync(int id, CancellationToken cancellationToken)
        {
            var pay = await _paymentMethodRepository.GetByIdAsync(cancellationToken, id);
            return pay;
        }

    }
}
