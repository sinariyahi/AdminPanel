using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProducerDetailRepository
    {
        Task<ProducerDetail> AddProducerDetailAsync(ProducerDetail producerDetail, CancellationToken cancellationToken);
        Task<ProducerDetail> FindProducerDetailAsync(int id, CancellationToken cancellationToken);
        Task<ProducerDetail> UpdateProducerDetailAsync(ProducerDetail producerDetail, CancellationToken cancellationToken);

    }
}
