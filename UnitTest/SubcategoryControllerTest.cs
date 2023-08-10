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
    public class SubcategoryControllerTest
    {
        private Mock<ISubcategoriesRepository> _subcategoryRepoMock;
        private Fixture _fixture;
        private SubcategoryController _subcategoryController;
        public SubcategoryControllerTest(

            )
        {
            _subcategoryRepoMock = new Mock<ISubcategoriesRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        }
        [Fact]
        public async Task Create_OkResult()
        {
            var cat = _fixture.Create<Subcategory>();
            //cat.Name= string.Empty;
            _subcategoryRepoMock.Setup(repo => repo.AddSubcategoryAsync(It.IsAny<Subcategory>(), new CancellationToken())).ReturnsAsync(cat);
            _subcategoryController = new SubcategoryController(_subcategoryRepoMock.Object);
            var result = await _subcategoryController.Post(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }


        [Fact]
        public async Task Create_BadRequestResult()
        {
            _subcategoryRepoMock.Setup(repo => repo.AddSubcategoryAsync(new Subcategory
            {
                Id=1,
                CategoryID=1,
                SubCatName=""
            }, new CancellationToken())).Throws(new Exception());
            _subcategoryController = new SubcategoryController(_subcategoryRepoMock.Object);
            var result = await _subcategoryController.Post(new Subcategory
            {
                Id = 1,
                CategoryID = 1,
                SubCatName = "sina"
            }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Update_OkResult()
        {
            var cat = _fixture.Create<Subcategory>();
            //cat.Name= string.Empty;
            _subcategoryRepoMock.Setup(repo => repo.UpdateSubcategoryAsync(It.IsAny<Subcategory>(), new CancellationToken())).ReturnsAsync(cat);
            _subcategoryController = new SubcategoryController(_subcategoryRepoMock.Object);
            var result = await _subcategoryController.Put(cat, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }
        [Fact]
        public async Task Update_BadRequestResult()
        {
            _subcategoryRepoMock.Setup(repo => repo.UpdateSubcategoryAsync(new Subcategory
            {
                Id = 2,
                CategoryID = 2,
                SubCatName = ""
            }, new CancellationToken())).Throws(new Exception());
            _subcategoryController = new SubcategoryController(_subcategoryRepoMock.Object);
            var result = await _subcategoryController.Put(new Subcategory
            {
                Id = 2,
                CategoryID = 2,
                SubCatName = "sina"
            }, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }
        [Fact]
        public async Task Get_OkResult()
        {
            //var cat = _fixture.();
            //cat.Name= string.Empty;
            _subcategoryRepoMock.Setup(repo => repo.FindSubcategoryAsync(1, new CancellationToken()));
            _subcategoryController = new SubcategoryController(_subcategoryRepoMock.Object);
            var result = await _subcategoryController.Get(1, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Xunit.Assert.True(obj.StatusCode == 200);
        }

        [Fact]
        public async Task Get_BadRequestResult()
        {
            _subcategoryRepoMock.Setup(repo => repo.FindSubcategoryAsync(1, new CancellationToken())).Throws(new Exception());
            _subcategoryController = new SubcategoryController(_subcategoryRepoMock.Object);
            var result = await _subcategoryController.Get(2, new CancellationToken());
            var obj = result.Result as ObjectResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
        }

    }
}
