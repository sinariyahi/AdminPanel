using Domain.Entities;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebAPi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoriesRepository subcategoriesRepository;
        private readonly IProducerRepository producerRepository;

        public SubcategoryController(ISubcategoriesRepository subcategoriesRepository, IProducerRepository producerRepository)
        {
            this.subcategoriesRepository = subcategoriesRepository;
            this.producerRepository = producerRepository;
        }

        //[HttpGet]
        //public ICollection<Subcategory> Index()
        //{
        //    return subcategoriesRepository.GetAllSubcategories();
        //}

        //[HttpGet("{id:required}")]
        //public SubcategoryPageDTO Subcategory(int id, int? page, int? limit)
        //{
        //    var result = new SubcategoryPageDTO
        //    {
        //        Subcategory = subcategoriesRepository.GetSubcategory(id),
        //        Products = subcategoriesRepository.GetProductsForSubcategory(id, page ?? 1, limit ?? 20)
        //    };

        //    foreach (var product in result.Products)
        //    {
        //        product.Producer = producerRepository.GetProducer(product.ProducerID);
        //    }

        //    return result;
        //}
    }
}

