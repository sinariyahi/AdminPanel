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
    public class ProducerDetailRepository : IBaseSevice , IProducerDetailRepository
    {
        private readonly IRepository<ProducerDetail> _producerDetailRepository;
        protected readonly IMapper _mapper;

        public ProducerDetailRepository(IRepository<ProducerDetail> producerDetailRepository, IMapper mapper)
        {
            _producerDetailRepository = producerDetailRepository;
            _mapper = mapper;
        }
        public async Task<ProducerDetail> AddProducerDetailAsync(ProducerDetail producerDetail, CancellationToken cancellationToken)
        {
            await _producerDetailRepository.AddAsync(producerDetail, cancellationToken);
            return producerDetail;
        }
        public async Task<ProducerDetail> UpdateProducerDetailAsync(ProducerDetail producerDetail, CancellationToken cancellationToken)
        {
            await _producerDetailRepository.UpdateAsync(producerDetail, cancellationToken);
            return producerDetail;
        }
        public async Task<ProducerDetail> FindProducerDetailAsync(int id, CancellationToken cancellationToken)
        {
            var pro = await _producerDetailRepository.GetByIdAsync(cancellationToken, id);
            return pro;
        }

    }
}
