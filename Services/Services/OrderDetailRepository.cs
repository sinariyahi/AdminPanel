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
    public class OrderDetailRepository : IBaseSevice , IOrderDetailRepository
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        protected readonly IMapper _mapper;

        public OrderDetailRepository(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken)
        {
            await _orderDetailRepository.AddAsync(orderDetail, cancellationToken);
            return orderDetail;
        }
        public async Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail, CancellationToken cancellationToken)
        {
            await _orderDetailRepository.UpdateAsync(orderDetail, cancellationToken);
            return orderDetail;
        }
        public async Task<OrderDetail> FindOrderDetailAsync(int id, CancellationToken cancellationToken)
        {
            var ord = await _orderDetailRepository.GetByIdAsync(cancellationToken, id);
            return ord;
        }

    }
}
