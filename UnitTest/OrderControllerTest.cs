using AutoFixture;
using Domain.Common;
using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
    public class OrderControllerTest
    {
        private Mock<IOrderRepository> _orderRepoMock;
        private Fixture _fixture;
        private OrderController _orderController;
        public OrderControllerTest(

            )
        {
            _orderRepoMock = new Mock<IOrderRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task GetAll_OkResult()
        {
            var catList = _fixture.CreateMany<OrderGridView>(5).ToList();
            var list = new PagedList<OrderGridView>();
            list.list = catList;
            _orderRepoMock.Setup(repo => repo.GetAll(2, 10, "", new CancellationToken())).ReturnsAsync(list);
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.GetAll(new CancellationToken(), "");
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, obj?.StatusCode);
        }
        [Fact]
        public async Task GetAll_BadRequestResult()
        {
            _orderRepoMock.Setup(repo => repo.GetAll(0, 10, "", new CancellationToken())).Throws(new Exception());
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.GetAll(new CancellationToken(), "");
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<Order>();
            //cat.Name= string.Empty;
            _orderRepoMock.Setup(repo => repo.AddOrderAsync(It.IsAny<Order>(), new CancellationToken())).ReturnsAsync(cat);
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.Post(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Create_BadRequestResult()
        {
            _orderRepoMock.Setup(repo => repo.AddOrderAsync(new Order {ID=1,Name="sina",ApplicationUserID="1", DateAndTime=new DateTime(),Note="1",ShippingMethodPrice=0 }, new CancellationToken())).Throws(new Exception());
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.Post(new Order { ID = 1, Name = "nima", ApplicationUserID = "1", DateAndTime = new DateTime(), Note = "1", ShippingMethodPrice = 1 }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<Order>();
            //cat.Name= string.Empty;
            _orderRepoMock.Setup(repo => repo.UpdateOrderAsync(It.IsAny<Order>(), new CancellationToken())).ReturnsAsync(cat);
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _orderRepoMock.Setup(repo => repo.UpdateOrderAsync(new Order { ID = 2, Name = "sina", ApplicationUserID = "2", DateAndTime = new DateTime(), Note = "2", ShippingMethodPrice = 0 }, new CancellationToken())).Throws(new Exception());
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.Put(new Order { ID = 2, Name = "sina", ApplicationUserID = "2", DateAndTime = new DateTime(), Note = "2", ShippingMethodPrice = 2 }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _orderRepoMock.Setup(repo => repo.FindOrderAsync(1, new CancellationToken()));
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _orderRepoMock.Setup(repo => repo.FindOrderAsync(1, new CancellationToken())).Throws(new Exception());
            _orderController = new OrderController(_orderRepoMock.Object);
            var result = await _orderController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
