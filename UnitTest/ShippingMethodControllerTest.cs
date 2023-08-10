using AutoFixture;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPi.Controllers.v1;
using Xunit;

namespace UnitTest
{
    public class ShippingMethodControllerTest
    {
        private Mock<IShippingMethodRepository> _shippingMethodRepoMock;
        private Fixture _fixture;
        private ShippingMethodController _shippingMethodController;
        public ShippingMethodControllerTest(

            )
        {
            _shippingMethodRepoMock = new Mock<IShippingMethodRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<ShippingMethod>();
            //cat.Name= string.Empty;
            _shippingMethodRepoMock.Setup(repo => repo.AddShippingMethodAsync(It.IsAny<ShippingMethod>(), new CancellationToken())).ReturnsAsync(cat);
            _shippingMethodController = new ShippingMethodController(_shippingMethodRepoMock.Object);
            var result = await _shippingMethodController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }


        [Fact]
        public async Task Create_BadRequestResult()
        {
            _shippingMethodRepoMock.Setup(repo => repo.AddShippingMethodAsync(new ShippingMethod
            {
                ID = 1,
                Name = "",
                Price = 0
            }, new CancellationToken())).Throws(new Exception());
            _shippingMethodController = new ShippingMethodController(_shippingMethodRepoMock.Object);
            var result = await _shippingMethodController.Post(new ShippingMethod
            {
                ID = 1,
                Name = "1",
                Price = 1
            }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<ShippingMethod>();
            //cat.Name= string.Empty;
            _shippingMethodRepoMock.Setup(repo => repo.UpdateShippingMethodAsync(It.IsAny<ShippingMethod>(), new CancellationToken())).ReturnsAsync(cat);
            _shippingMethodController = new ShippingMethodController(_shippingMethodRepoMock.Object);
            var result = await _shippingMethodController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _shippingMethodRepoMock.Setup(repo => repo.UpdateShippingMethodAsync(new ShippingMethod
            {
                ID = 2,
                Name = "",
                Price = 0
            }, new CancellationToken())).Throws(new Exception());
            _shippingMethodController = new ShippingMethodController(_shippingMethodRepoMock.Object);
            var result = await _shippingMethodController.Put(new ShippingMethod
            {
                ID = 2,
                Name = "2",
                Price = 2
            }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _shippingMethodRepoMock.Setup(repo => repo.FindShippingMethodAsync(1, new CancellationToken()));
            _shippingMethodController = new ShippingMethodController(_shippingMethodRepoMock.Object);
            var result = await _shippingMethodController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _shippingMethodRepoMock.Setup(repo => repo.FindShippingMethodAsync(1, new CancellationToken())).Throws(new Exception());
            _shippingMethodController = new ShippingMethodController(_shippingMethodRepoMock.Object);
            var result = await _shippingMethodController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }

    }
}
