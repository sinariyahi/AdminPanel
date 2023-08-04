using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class CartItemDTO
    {
        public long ProductID { get; set; }
        public int Quantity { get; set; }
    
    }
}
