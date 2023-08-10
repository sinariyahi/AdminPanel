using AutoFixture;
using Domain.Common;
using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Interface;
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
    public class DiscountControllerTest
    {
        private Mock<IDiscountRepository> _discountRepoMock;
        private Fixture _fixture;
        private DiscountController _discountController;
        public DiscountControllerTest(

            )
        {
            _discountRepoMock = new Mock<IDiscountRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<Discount>();
            //cat.Name= string.Empty;
            _discountRepoMock.Setup(repo => repo.AddDiscountAsync(It.IsAny<Discount>(), new CancellationToken())).ReturnsAsync(cat);
            _discountController = new DiscountController(_discountRepoMock.Object);
            var result = await _discountController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Create_BadRequestResult()
        {
                _discountRepoMock.Setup(repo => repo.AddDiscountAsync(new Discount {ID=1,ProductID=1,Percentage=0,StartTime=new DateTime(),EndTime= new DateTime() }, new CancellationToken())).Throws(new Exception());
            _discountController = new DiscountController(_discountRepoMock.Object);
            var result = await _discountController.Post(new Discount { ID = 1, ProductID = 1, Percentage = 1, StartTime = new DateTime(), EndTime = new DateTime() }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<Discount>();
            //cat.Name= string.Empty;
            _discountRepoMock.Setup(repo => repo.UpdateDiscountAsync(It.IsAny<Discount>(), new CancellationToken())).ReturnsAsync(cat);
            _discountController = new DiscountController(_discountRepoMock.Object);
            var result = await _discountController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _discountRepoMock.Setup(repo => repo.UpdateDiscountAsync(new Discount { ID = 1, ProductID = 1, Percentage = 0, StartTime = new DateTime(), EndTime = new DateTime() }, new CancellationToken())).Throws(new Exception());
            _discountController = new DiscountController(_discountRepoMock.Object);
            var result = await _discountController.Put(new Discount { ID = 1, ProductID = 1, Percentage = 1, StartTime = new DateTime(), EndTime = new DateTime() }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _discountRepoMock.Setup(repo => repo.FindDiscountAsync(1, new CancellationToken()));
            _discountController = new DiscountController(_discountRepoMock.Object);
            var result = await _discountController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _discountRepoMock.Setup(repo => repo.FindDiscountAsync(1, new CancellationToken())).Throws(new Exception());
            _discountController = new DiscountController(_discountRepoMock.Object);
            var result = await _discountController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
