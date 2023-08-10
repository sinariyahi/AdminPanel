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
    public class ProductControllerTest
    {
        private Mock<IProductRepository> _productRepoMock;
        private Fixture _fixture;
        private ProductController _productController;
        public ProductControllerTest(

            )
        {
            _productRepoMock = new Mock<IProductRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task GetAll_OkResult()
        {
            var catList = _fixture.CreateMany<ProductGridView>(5).ToList();
            var list = new PagedList<ProductGridView>();
            list.list = catList;
            _productRepoMock.Setup(repo => repo.GetAll(2, 10, "", new CancellationToken())).ReturnsAsync(list);
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.GetAll(new CancellationToken(), "");
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, obj?.StatusCode);
        }
        [Fact]
        public async Task GetAll_BadRequestResult()
        {
            _productRepoMock.Setup(repo => repo.GetAll(0, 10, "", new CancellationToken())).Throws(new Exception());
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.GetAll(new CancellationToken(), "");
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<Product>();
            //cat.Name= string.Empty;
            _productRepoMock.Setup(repo => repo.AddProductAsync(It.IsAny<Product>(), new CancellationToken())).ReturnsAsync(cat);
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.Post(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
    
        [Fact]
        public async Task Create_BadRequestResult()
        {
            _productRepoMock.Setup(repo => repo.AddProductAsync(new Product { ID = 1, ProducerID = 1, CategoryID = 1, SubcategoryID = 1, Name = "", Price = 0, AvailableQuantity = 0 }, new CancellationToken())).Throws(new Exception());
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.Post(new Product { ID = 1, ProducerID = 1, CategoryID = 1, SubcategoryID = 1, Name = "sina", Price = 1, AvailableQuantity = 1 }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<Product>();
            //cat.Name= string.Empty;
            _productRepoMock.Setup(repo => repo.UpdateProductAsync(It.IsAny<Product>(), new CancellationToken())).ReturnsAsync(cat);
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _productRepoMock.Setup(repo => repo.UpdateProductAsync(new Product {  }, new CancellationToken())).Throws(new Exception());
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.Put(new Product { }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _productRepoMock.Setup(repo => repo.FindProductAsync(1, new CancellationToken()));
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _productRepoMock.Setup(repo => repo.FindProductAsync(1, new CancellationToken())).Throws(new Exception());
            _productController = new ProductController(_productRepoMock.Object);
            var result = await _productController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
