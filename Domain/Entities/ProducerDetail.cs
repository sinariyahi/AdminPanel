using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProducerDetail : IEntity
    {
        public long ID { get; set; }

        public int ProducerID { get; set; }

        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(200)]
        public string City { get; set; }

        [StringLength(200)]
        public string Country { get; set; }

        public Producer Producer { get; set; }
    }
}
