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
    public class PaymentTypeControllerTest
    {
        private Mock<IPaymentTypeRepository> _paymentTypeRepoMock;
        private Fixture _fixture;
        private PaymentTypeController _paymentTypeController;
        public PaymentTypeControllerTest(

            )
        {
            _paymentTypeRepoMock = new Mock<IPaymentTypeRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<PaymentType>();
            //cat.Name= string.Empty;
            _paymentTypeRepoMock.Setup(repo => repo.AddPaymentTypeAsync(It.IsAny<PaymentType>(), new CancellationToken())).ReturnsAsync(cat);
            _paymentTypeController = new PaymentTypeController(_paymentTypeRepoMock.Object);
            var result = await _paymentTypeController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Create_BadRequestResult()
        {
            _paymentTypeRepoMock.Setup(repo => repo.AddPaymentTypeAsync(new PaymentType {ID=1,Name="" }, new CancellationToken())).Throws(new Exception());
            _paymentTypeController = new PaymentTypeController(_paymentTypeRepoMock.Object);
            var result = await _paymentTypeController.Post(new PaymentType { ID = 1, Name = "sina" }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<PaymentType>();
            //cat.Name= string.Empty;
            _paymentTypeRepoMock.Setup(repo => repo.UpdatePaymentTypeAsync(It.IsAny<PaymentType>(), new CancellationToken())).ReturnsAsync(cat);
            _paymentTypeController = new PaymentTypeController(_paymentTypeRepoMock.Object);
            var result = await _paymentTypeController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _paymentTypeRepoMock.Setup(repo => repo.UpdatePaymentTypeAsync(new PaymentType { ID = 2, Name="" }, new CancellationToken())).Throws(new Exception());
            _paymentTypeController = new PaymentTypeController(_paymentTypeRepoMock.Object);
            var result = await _paymentTypeController.Put(new PaymentType { ID = 2,Name="sina" }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _paymentTypeRepoMock.Setup(repo => repo.FindPaymentTypeAsync(1, new CancellationToken()));
            _paymentTypeController = new PaymentTypeController(_paymentTypeRepoMock.Object);
            var result = await _paymentTypeController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _paymentTypeRepoMock.Setup(repo => repo.FindPaymentTypeAsync(1, new CancellationToken())).Throws(new Exception());
            _paymentTypeController = new PaymentTypeController(_paymentTypeRepoMock.Object);
            var result = await _paymentTypeController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
