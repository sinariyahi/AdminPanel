using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InvoiceDetail : IEntity
    {
        public long ID { get; set; }

        public long InvoiceID { get; set; }

        public long ProductID { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemPrice { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
