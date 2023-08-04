

using AutoFixture;
using Domain.Common;
using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Interface;
using WebAPi.Controllers.v1;
using Xunit;

namespace UnitTest;


public class CateoryControllerTest
{
    private Mock<ICategoriesRepository> _categoriesRepoMock;
    private Fixture _fixture;
    private CategoryController _categoryController;
    public CateoryControllerTest(

        )
    {
        _categoriesRepoMock = new Mock<ICategoriesRepository>();
        _fixture = new Fixture();
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
        .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());        

    }
    [Fact]
    public async Task Get_OkResult()
    {
        var catList = _fixture.CreateMany<CateGoryGridView>(5).ToList();
        var list = new PagedList<CateGoryGridView>();
        list.list = catList;
        _categoriesRepoMock.Setup(repo => repo.GetAll(2, 10, "", new CancellationToken())).ReturnsAsync(list);
        _categoryController = new CategoryController(_categoriesRepoMock.Object);
        var result = await _categoryController.GetAll(new CancellationToken(), "");
        var obj = result as ObjectResult;
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, obj?.StatusCode);
    }
    [Fact]
    public async Task Get_BadRequestResult()
    {
        _categoriesRepoMock.Setup(repo => repo.GetAll(0, 10, "", new CancellationToken())).Throws(new Exception());
        _categoryController = new CategoryController(_categoriesRepoMock.Object);
        var result = await _categoryController.GetAll(new CancellationToken(), "");
        var obj = result as ObjectResult;
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, obj?.StatusCode);
    }
    [Fact]
    public async Task Create_OkResult()
    {
        var cat = _fixture.Create<Category>();
        //cat.Name= string.Empty;
        _categoriesRepoMock.Setup(repo => repo.AddCategoryAsync(It.IsAny<Category>(), new CancellationToken())).ReturnsAsync(cat);
        _categoryController = new CategoryController(_categoriesRepoMock.Object);
        var result = await _categoryController.Post(cat, new CancellationToken());
        var obj = result as ObjectResult;
        Xunit.Assert.True(obj.StatusCode == 200);
    }
}