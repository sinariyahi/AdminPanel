using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review:IEntity
    {
        public long ID { get; set; }

        public long ApplicationUserID { get; set; }

        public long ProductID { get; set; }

        [Required]
        [Range(1, 6)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Content { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
        public Product Product { get; set; }
    }
}
