using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductFeature : IEntity
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public Product Product { get; set; }

    }
}
