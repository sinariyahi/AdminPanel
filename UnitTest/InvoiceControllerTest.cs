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
    public class InvoiceControllerTest
    {
        private Mock<IInvoiceRepository> _invoiceRepoMock;
        private Fixture _fixture;
        private InvoiceController _invoiceController;
        public InvoiceControllerTest(

            )
        {
            _invoiceRepoMock = new Mock<IInvoiceRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }

        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<Invoice>();
            //cat.Name= string.Empty;
            _invoiceRepoMock.Setup(repo => repo.AddInvoiceAsync(It.IsAny<Invoice>(), new CancellationToken())).ReturnsAsync(cat);
            _invoiceController = new InvoiceController(_invoiceRepoMock.Object);
            var result = await _invoiceController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Create_BadRequestResult()
        {
            _invoiceRepoMock.Setup(repo => repo.AddInvoiceAsync(new Invoice {ID=1, ApplicationUserID="", OrderID=1, DateIssued=new DateTime() }, new CancellationToken())).Throws(new Exception());
            _invoiceController = new InvoiceController(_invoiceRepoMock.Object);
            var result = await _invoiceController.Post(new Invoice { ID = 1, ApplicationUserID = "1", OrderID = 1, DateIssued = new DateTime() }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<Invoice>();
            //cat.Name= string.Empty;
            _invoiceRepoMock.Setup(repo => repo.UpdateInvoiceAsync(It.IsAny<Invoice>(), new CancellationToken())).ReturnsAsync(cat);
            _invoiceController = new InvoiceController(_invoiceRepoMock.Object);
            var result = await _invoiceController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _invoiceRepoMock.Setup(repo => repo.UpdateInvoiceAsync(new Invoice { ID = 2, ApplicationUserID = "", OrderID = 2, DateIssued = new DateTime() }, new CancellationToken())).Throws(new Exception());
            _invoiceController = new InvoiceController(_invoiceRepoMock.Object);
            var result = await _invoiceController.Put(new Invoice { ID = 2, ApplicationUserID = "2", OrderID = 2, DateIssued = new DateTime() }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _invoiceRepoMock.Setup(repo => repo.FindInvoiceAsync(1, new CancellationToken()));
            _invoiceController = new InvoiceController(_invoiceRepoMock.Object);
            var result = await _invoiceController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _invoiceRepoMock.Setup(repo => repo.FindInvoiceAsync(1, new CancellationToken())).Throws(new Exception());
            _invoiceController = new InvoiceController(_invoiceRepoMock.Object);
            var result = await _invoiceController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
