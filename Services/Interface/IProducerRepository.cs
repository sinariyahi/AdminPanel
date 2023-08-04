using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProducerRepository
    {
        Task<Producer> AddProducerAsync(Producer producer, CancellationToken cancellationToken);
        Task<Producer> FindProducerAsync(int id, CancellationToken cancellationToken);
        Task<Producer> UpdateProducerAsync(Producer producer, CancellationToken cancellationToken);

    }
}
