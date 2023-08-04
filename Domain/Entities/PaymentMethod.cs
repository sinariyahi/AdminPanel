using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentMethod : IEntity
    {
        public long ID { get; set; }

        public int PaymentTypeID { get; set; }

        public long ApplicationUserID { get; set; }

        [Required]
        [StringLength(512)]
        public string Value { get; set; }

        public PaymentType PaymentType { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
