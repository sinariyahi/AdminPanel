using AutoMapper;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class CategoryPageDTO
    {
        public Category Category { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    public class CateGoryGridView:IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void CreateMappings(Profile profile)
        {
            var mappingExpression = profile.CreateMap<CateGoryGridView, Category>();
            mappingExpression.ReverseMap();
            //CustomMappings(mappingExpression.ReverseMap());
        }

    }
}
