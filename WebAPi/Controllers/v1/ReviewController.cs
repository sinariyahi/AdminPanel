using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.Services;

namespace WebAPi.Controllers.v1
{
    public class ReviewController : BaseController
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(Review review, CancellationToken cancellationToken)
        {
            return Ok(await _reviewRepository.AddReviewAsync(review, cancellationToken));
        }
        [HttpPut("update")]
        public async Task<ActionResult<Review>> Put(Review review, CancellationToken cancellationToken)
        {
            return Ok(await _reviewRepository.UpdateReviewAsync(review, cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> Get(int id, CancellationToken cancellationToken)
        {
            return Ok(await _reviewRepository.FindReviewAsync(id, cancellationToken));
        }

    }
}
