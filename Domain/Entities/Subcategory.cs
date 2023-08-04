using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subcategory : IEntity
    {
        public int Id { get; set; }
        public int CategoryID { get; set; }

        [Required]
        [StringLength(200)]
        public string SubCatName { get; set; }

        public Category Category { get; set; }

    }
}
