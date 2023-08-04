using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RefreshToken : IEntity
    {
        public long ID { get; set; }

        public string ApplicationUserID { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }
}
