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
    public class ProducerControllerTest
    {
        private Mock<IProducerRepository> _producerRepoMock;
        private Fixture _fixture;
        private ProducerController _producerController;
        public ProducerControllerTest(

            )
        {
            _producerRepoMock = new Mock<IProducerRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<Producer>();
            //cat.Name= string.Empty;
            _producerRepoMock.Setup(repo => repo.AddProducerAsync(It.IsAny<Producer>(), new CancellationToken())).ReturnsAsync(cat);
            _producerController = new ProducerController(_producerRepoMock.Object);
            var result = await _producerController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Create_BadRequestResult()
        {
            _producerRepoMock.Setup(repo => repo.AddProducerAsync(new Producer {ID=1,Name=""  }, new CancellationToken())).Throws(new Exception());
            _producerController = new ProducerController(_producerRepoMock.Object);
            var result = await _producerController.Post(new Producer { ID = 1, Name = "sina" }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<Producer>();
            //cat.Name= string.Empty;
            _producerRepoMock.Setup(repo => repo.UpdateProducerAsync(It.IsAny<Producer>(), new CancellationToken())).ReturnsAsync(cat);
            _producerController = new ProducerController(_producerRepoMock.Object);
            var result = await _producerController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _producerRepoMock.Setup(repo => repo.UpdateProducerAsync(new Producer { ID = 2, Name = "" }, new CancellationToken())).Throws(new Exception());
            _producerController = new ProducerController(_producerRepoMock.Object);
            var result = await _producerController.Put(new Producer { ID = 2, Name = "sina" }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _producerRepoMock.Setup(repo => repo.FindProducerAsync(1, new CancellationToken()));
            _producerController = new ProducerController(_producerRepoMock.Object);
            var result = await _producerController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _producerRepoMock.Setup(repo => repo.FindProducerAsync(1, new CancellationToken())).Throws(new Exception());
            _producerController = new ProducerController(_producerRepoMock.Object);
            var result = await _producerController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
