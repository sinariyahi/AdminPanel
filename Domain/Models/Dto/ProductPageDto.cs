using AutoMapper;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class ProductPageDto
    {
        public Producer Producer { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Discount> Discounts { get; set; }
    }
    public class ProductGridView : IHaveCustomMapping
    {
        public long ID { get; set; }
        public int ProducerID { get; set; }
        public int CategoryID { get; set; }
        public int SubcategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }

        public void CreateMappings(Profile profile)
        {
            var mappingExpression = profile.CreateMap<ProductGridView, Product>();
            mappingExpression.ReverseMap();
            //CustomMappings(mappingExpression.ReverseMap());
        }

    }
}
