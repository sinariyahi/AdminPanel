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
    public class PaymentTypeRepository : IBaseSevice , IPaymentTypeRepository
    {
        private readonly IRepository<PaymentType> _paymentTypeRepository;
        protected readonly IMapper _mapper;

        public PaymentTypeRepository(IRepository<PaymentType> paymentTypeRepository, IMapper mapper)
        {
            _paymentTypeRepository = paymentTypeRepository;
            _mapper = mapper;
        }
        public async Task<PaymentType> AddPaymentTypeAsync(PaymentType paymentType, CancellationToken cancellationToken)
        {
            await _paymentTypeRepository.AddAsync(paymentType, cancellationToken);
            return paymentType;
        }
        public async Task<PaymentType> UpdatePaymentTypeAsync(PaymentType paymentType, CancellationToken cancellationToken)
        {
            await _paymentTypeRepository.UpdateAsync(paymentType, cancellationToken);
            return paymentType;
        }
        public async Task<PaymentType> FindPaymentTypeAsync(int id, CancellationToken cancellationToken)
        {
            var pay = await _paymentTypeRepository.GetByIdAsync(cancellationToken, id);
            return pay;
        }

    }
}
