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
    public class ReviewRepository : IBaseSevice , IReviewRepository
    {
        private readonly IRepository<Review> _reviewRepository;
        protected readonly IMapper _mapper;

        public ReviewRepository(IRepository<Review> reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public async Task<Review> AddReviewAsync(Review review, CancellationToken cancellationToken)
        {
            await _reviewRepository.AddAsync(review, cancellationToken);
            return review;
        }
        public async Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken)
        {
            await _reviewRepository.UpdateAsync(review, cancellationToken);
            return review;
        }
        public async Task<Review> FindReviewAsync(int id, CancellationToken cancellationToken)
        {
            var pro = await _reviewRepository.GetByIdAsync(cancellationToken, id);
            return pro;
        }

    }
}
