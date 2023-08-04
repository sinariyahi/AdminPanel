using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class SubcategoryPageDTO
    {
        public Subcategory Subcategory { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
