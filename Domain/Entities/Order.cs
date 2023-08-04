using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : IEntity
    {
        public long ID { get; set; }

        public string Name { get; set; }
        public string ApplicationUserID { get; set; }

        public int ShippingMethodID { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [StringLength(400)]
        public string Note { get; set; }

        public decimal ShippingMethodPrice { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public ICollection<OrderFeature> OrderFeatures;
        public ICollection<OrderDetail> Details { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
