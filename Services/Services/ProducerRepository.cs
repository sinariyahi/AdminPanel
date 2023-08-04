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
    public class ProducerRepository : IBaseSevice , IProducerRepository
    {
        private readonly IRepository<Producer> _producerRepository;
        protected readonly IMapper _mapper;

        public ProducerRepository(IRepository<Producer> producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }
        public async Task<Producer> AddProducerAsync(Producer producer, CancellationToken cancellationToken)
        {
            await _producerRepository.AddAsync(producer, cancellationToken);
            return producer;
        }
        public async Task<Producer> UpdateProducerAsync(Producer producer, CancellationToken cancellationToken)
        {
            await _producerRepository.UpdateAsync(producer, cancellationToken);
            return producer;
        }
        public async Task<Producer> FindProducerAsync(int id, CancellationToken cancellationToken)
        {
            var pro = await _producerRepository.GetByIdAsync(cancellationToken, id);
            return pro;
        }

    }
}
