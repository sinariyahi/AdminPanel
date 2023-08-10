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
    public class OrderDetailControllerTest
    {
        private Mock<IOrderDetailRepository> _orderDetailRepoMock;
        private Fixture _fixture;
        private OrderDetailController _orderDetailController;
        public OrderDetailControllerTest(

            )
        {
            _orderDetailRepoMock = new Mock<IOrderDetailRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<OrderDetail>();
            //cat.Name= string.Empty;
            _orderDetailRepoMock.Setup(repo => repo.AddOrderDetailAsync(It.IsAny<OrderDetail>(), new CancellationToken())).ReturnsAsync(cat);
            _orderDetailController = new OrderDetailController(_orderDetailRepoMock.Object);
            var result = await _orderDetailController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        
        [Fact]
        public async Task Create_BadRequestResult()
        {
            _orderDetailRepoMock.Setup(repo => repo.AddOrderDetailAsync(new OrderDetail {ID=1,OrderID=1,ProductID=1,Quantity=0  }, new CancellationToken())).Throws(new Exception());
            _orderDetailController = new OrderDetailController(_orderDetailRepoMock.Object);
            var result = await _orderDetailController.Post(new OrderDetail { ID = 1, OrderID = 1, ProductID = 1, Quantity = 0 }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<OrderDetail>();
            //cat.Name= string.Empty;
            _orderDetailRepoMock.Setup(repo => repo.UpdateOrderDetailAsync(It.IsAny<OrderDetail>(), new CancellationToken())).ReturnsAsync(cat);
            _orderDetailController = new OrderDetailController(_orderDetailRepoMock.Object);
            var result = await _orderDetailController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _orderDetailRepoMock.Setup(repo => repo.UpdateOrderDetailAsync(new OrderDetail { ID = 2, OrderID = 2, ProductID = 2, Quantity = 0 }, new CancellationToken())).Throws(new Exception());
            _orderDetailController = new OrderDetailController(_orderDetailRepoMock.Object);
            var result = await _orderDetailController.Put(new OrderDetail { ID = 2, OrderID = 2, ProductID = 2, Quantity = 2 }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _orderDetailRepoMock.Setup(repo => repo.FindOrderDetailAsync(1, new CancellationToken()));
            _orderDetailController = new OrderDetailController(_orderDetailRepoMock.Object);
            var result = await _orderDetailController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _orderDetailRepoMock.Setup(repo => repo.FindOrderDetailAsync(1, new CancellationToken())).Throws(new Exception());
            _orderDetailController = new OrderDetailController(_orderDetailRepoMock.Object);
            var result = await _orderDetailController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
