using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice : IEntity
    {
        public long ID { get; set; }

        public string ApplicationUserID { get; set; }

        public long OrderID { get; set; }

        public decimal TotalValue { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
        public Order Order { get; set; }
        public ICollection<InvoiceDetail> Details { get; set; }
    
    }
}
