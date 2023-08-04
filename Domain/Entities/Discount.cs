using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Discount : IEntity
    {
        public long ID { get; set; }

        public long ProductID { get; set; }

        [Required]
        public decimal Percentage { get; set; }

        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public Product Product { get; set; }

      
    }
}
