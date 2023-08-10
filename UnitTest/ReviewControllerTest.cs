using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Interface;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPi.Controllers.v1;
using Xunit;

namespace UnitTest
{
    public class ReviewControllerTest
    {
        private Mock<IReviewRepository> _reviewRepoMock;
        private Fixture _fixture;
        private ReviewController _reviewController;
        public ReviewControllerTest(

            )
        {
            _reviewRepoMock = new Mock<IReviewRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<Review>();
            //cat.Name= string.Empty;
            _reviewRepoMock.Setup(repo => repo.AddReviewAsync(It.IsAny<Review>(), new CancellationToken())).ReturnsAsync(cat);
            _reviewController = new ReviewController(_reviewRepoMock.Object);
            var result = await _reviewController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        
        [Fact]
        public async Task Create_BadRequestResult()
        {
            _reviewRepoMock.Setup(repo => repo.AddReviewAsync(new Review
            {
                ID = 1,
                ApplicationUserID = 1,
                ProductID = 1,
                Rating = 0,
                Content = ""
            }, new CancellationToken())).Throws(new Exception());
            _reviewController = new ReviewController(_reviewRepoMock.Object);
            var result = await _reviewController.Post(new Review
            {
                ID=1,
                ApplicationUserID=1,
                ProductID=1,
                Rating=1,
                Content="1"
            }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<Review>();
            //cat.Name= string.Empty;
            _reviewRepoMock.Setup(repo => repo.UpdateReviewAsync(It.IsAny<Review>(), new CancellationToken())).ReturnsAsync(cat);
            _reviewController = new ReviewController(_reviewRepoMock.Object);
            var result = await _reviewController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _reviewRepoMock.Setup(repo => repo.UpdateReviewAsync(new Review
            {
                ID = 2,
                ApplicationUserID = 2,
                ProductID = 2,
                Rating = 0,
                Content = ""
            }, new CancellationToken())).Throws(new Exception());
            _reviewController = new ReviewController(_reviewRepoMock.Object);
            var result = await _reviewController.Put(new Review
            {
                ID = 2,
                ApplicationUserID = 2,
                ProductID = 2,
                Rating = 2,
                Content = "2"
            }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _reviewRepoMock.Setup(repo => repo.FindReviewAsync(1, new CancellationToken()));
            _reviewController = new ReviewController(_reviewRepoMock.Object);
            var result = await _reviewController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _reviewRepoMock.Setup(repo => repo.FindReviewAsync(1, new CancellationToken())).Throws(new Exception());
            _reviewController = new ReviewController(_reviewRepoMock.Object);
            var result = await _reviewController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }

    }
}
