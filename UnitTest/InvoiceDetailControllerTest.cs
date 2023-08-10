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
    public class InvoiceDetailControllerTest
    {
        private Mock<IInvoiceDetailRepository> _invoiceDetailRepoMock;
        private Fixture _fixture;
        private InvoiceDetailController _invoiceDetailController;
        public InvoiceDetailControllerTest(

            )
        {
            _invoiceDetailRepoMock = new Mock<IInvoiceDetailRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }

        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<InvoiceDetail>();
            //cat.Name= string.Empty;
            _invoiceDetailRepoMock.Setup(repo => repo.AddInvoiceDetailAsync(It.IsAny<InvoiceDetail>(), new CancellationToken())).ReturnsAsync(cat);
            _invoiceDetailController = new InvoiceDetailController(_invoiceDetailRepoMock.Object);
            var result = await _invoiceDetailController.Post(cat, new CancellationToken());
            var obj = result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        
        [Fact]
        public async Task Create_BadRequestResult()
        {
            _invoiceDetailRepoMock.Setup(repo => repo.AddInvoiceDetailAsync(new InvoiceDetail{ID=1, InvoiceID=1, ProductID=1, ItemQuantity =1 , ItemPrice =0}, new CancellationToken())).Throws(new Exception());
            _invoiceDetailController = new InvoiceDetailController(_invoiceDetailRepoMock.Object);
            var result = await _invoiceDetailController.Post(new InvoiceDetail { ID = 1, InvoiceID = 1, ProductID = 1, ItemQuantity = 1, ItemPrice = 1 }, new CancellationToken());
            var obj = result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<InvoiceDetail>();
            //cat.Name= string.Empty;
            _invoiceDetailRepoMock.Setup(repo => repo.UpdateInvoiceDetailAsync(It.IsAny<InvoiceDetail>(), new CancellationToken())).ReturnsAsync(cat);
            _invoiceDetailController = new InvoiceDetailController(_invoiceDetailRepoMock.Object);
            var result = await _invoiceDetailController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _invoiceDetailRepoMock.Setup(repo => repo.UpdateInvoiceDetailAsync(new InvoiceDetail { ID = 2, InvoiceID = 2, ProductID = 2, ItemQuantity = 2, ItemPrice = 0 }, new CancellationToken())).Throws(new Exception());
            _invoiceDetailController = new InvoiceDetailController(_invoiceDetailRepoMock.Object);
            var result = await _invoiceDetailController.Put(new InvoiceDetail { ID = 2, InvoiceID = 2, ProductID = 2, ItemQuantity = 2, ItemPrice = 2 }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _invoiceDetailRepoMock.Setup(repo => repo.FindInvoiceDetailAsync(1, new CancellationToken()));
            _invoiceDetailController = new InvoiceDetailController(_invoiceDetailRepoMock.Object);
            var result = await _invoiceDetailController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _invoiceDetailRepoMock.Setup(repo => repo.FindInvoiceDetailAsync(1, new CancellationToken())).Throws(new Exception());
            _invoiceDetailController = new InvoiceDetailController(_invoiceDetailRepoMock.Object);
            var result = await _invoiceDetailController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
    }
}
