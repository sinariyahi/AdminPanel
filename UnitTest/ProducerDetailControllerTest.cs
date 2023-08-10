using AutoFixture;
using Domain.Entities;
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
    public class ProducerDetailControllerTest
    {
        private Mock<IProducerDetailRepository> _producerDetailRepoMock;
        private Fixture _fixture;
        private ProducerDetailController _producerDetailController;
        public ProducerDetailControllerTest(

            )
        {
            _producerDetailRepoMock = new Mock<IProducerDetailRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<ProducerDetail>();
            //cat.Name= string.Empty;
            _producerDetailRepoMock.Setup(repo => repo.AddProducerDetailAsync(It.IsAny<ProducerDetail>(), new CancellationToken())).ReturnsAsync(cat);
            _producerDetailController = new ProducerDetailController(_producerDetailRepoMock.Object);
            var result = await _producerDetailController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Create_BadRequestResult()
        {
            _producerDetailRepoMock.Setup(repo => repo.AddProducerDetailAsync(new ProducerDetail {
                ID = 1,
                ProducerID = 1,
                PhoneNumber = "09362322511",
                Email = "sina8281@gmail.com",
                Address1 = "Iran",
                Address2 = "Tehran",
                City = "",
                Country = ""
            }, new CancellationToken())).Throws(new Exception());
            _producerDetailController = new ProducerDetailController(_producerDetailRepoMock.Object);
            var result = await _producerDetailController.Post(new ProducerDetail {
                ID = 1,
                ProducerID = 1,
                PhoneNumber = "09362322511",
                Email = "sina8281@gmail.com",
                Address1 = "Iran",
                Address2 = "Tehran",
                City = "Tehran",
                Country = "Iran"
            }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<ProducerDetail>();
            //cat.Name= string.Empty;
            _producerDetailRepoMock.Setup(repo => repo.UpdateProducerDetailAsync(It.IsAny<ProducerDetail>(), new CancellationToken())).ReturnsAsync(cat);
            _producerDetailController = new ProducerDetailController(_producerDetailRepoMock.Object);
            var result = await _producerDetailController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _producerDetailRepoMock.Setup(repo => repo.UpdateProducerDetailAsync(new ProducerDetail {
                ID = 2,
                ProducerID = 2,
                PhoneNumber = "09306628281",
                Email = "sina.riyahi76@gmail.com",
                Address1 = "",
                Address2 = "",
                City = "Tehran",
                Country = "Iran"
            }, new CancellationToken())).Throws(new Exception());
            _producerDetailController = new ProducerDetailController(_producerDetailRepoMock.Object);
            var result = await _producerDetailController.Put(new ProducerDetail {
                ID = 2,
                ProducerID = 2,
                PhoneNumber = "09306628281",
                Email = "sina.riyahi76@gmail.com",
                Address1 = "Iran",
                Address2 = "Tehran",
                City = "Tehran",
                Country = "Iran"
            }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _producerDetailRepoMock.Setup(repo => repo.FindProducerDetailAsync(1, new CancellationToken()));
            _producerDetailController = new ProducerDetailController(_producerDetailRepoMock.Object);
            var result = await _producerDetailController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _producerDetailRepoMock.Setup(repo => repo.FindProducerDetailAsync(1, new CancellationToken())).Throws(new Exception());
            _producerDetailController = new ProducerDetailController(_producerDetailRepoMock.Object);
            var result = await _producerDetailController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
