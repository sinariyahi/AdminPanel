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
    public class PaymentMethodControllerTest
    {
        private Mock<IPaymentMethodRepository> _paymentMethodRepoMock;
        private Fixture _fixture;
        private PaymentMethodController _paymentMethodController;
        public PaymentMethodControllerTest(

            )
        {
            _paymentMethodRepoMock = new Mock<IPaymentMethodRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<PaymentMethod>();
            //cat.Name= string.Empty;
            _paymentMethodRepoMock.Setup(repo => repo.AddPaymentMethodAsync(It.IsAny<PaymentMethod>(), new CancellationToken())).ReturnsAsync(cat);
            _paymentMethodController = new PaymentMethodController(_paymentMethodRepoMock.Object);
            var result = await _paymentMethodController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
    
        [Fact]
        public async Task Create_BadRequestResult()
        {
            _paymentMethodRepoMock.Setup(repo => repo.AddPaymentMethodAsync(new PaymentMethod {ID=1,PaymentTypeID=1, ApplicationUserID=1,Value="" }, new CancellationToken())).Throws(new Exception());
            _paymentMethodController = new PaymentMethodController(_paymentMethodRepoMock.Object);
            var result = await _paymentMethodController.Post(new PaymentMethod { ID = 1, PaymentTypeID = 1, ApplicationUserID = 1, Value = "1" }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<PaymentMethod>();
            //cat.Name= string.Empty;
            _paymentMethodRepoMock.Setup(repo => repo.UpdatePaymentMethodAsync(It.IsAny<PaymentMethod>(), new CancellationToken())).ReturnsAsync(cat);
            _paymentMethodController = new PaymentMethodController(_paymentMethodRepoMock.Object);
            var result = await _paymentMethodController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _paymentMethodRepoMock.Setup(repo => repo.UpdatePaymentMethodAsync(new PaymentMethod { ID = 2, PaymentTypeID = 2, ApplicationUserID = 2, Value = "" }, new CancellationToken())).Throws(new Exception());
            _paymentMethodController = new PaymentMethodController(_paymentMethodRepoMock.Object);
            var result = await _paymentMethodController.Put(new PaymentMethod { ID = 2, PaymentTypeID = 2, ApplicationUserID = 2, Value = "2" }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _paymentMethodRepoMock.Setup(repo => repo.FindPaymentMethodAsync(1, new CancellationToken()));
            _paymentMethodController = new PaymentMethodController(_paymentMethodRepoMock.Object);
            var result = await _paymentMethodController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _paymentMethodRepoMock.Setup(repo => repo.FindPaymentMethodAsync(1, new CancellationToken())).Throws(new Exception());
            _paymentMethodController = new PaymentMethodController(_paymentMethodRepoMock.Object);
            var result = await _paymentMethodController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
