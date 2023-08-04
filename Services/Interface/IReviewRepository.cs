using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IReviewRepository
    {
        Task<Review> AddReviewAsync(Review review, CancellationToken cancellationToken);
        Task<Review> FindReviewAsync(int id, CancellationToken cancellationToken);
        Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken);

    }
}
