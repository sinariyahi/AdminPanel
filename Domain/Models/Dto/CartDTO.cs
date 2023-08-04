using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class CartDTO
    {
        public ICollection<CartItemDTO> CartItems { get; set; }
        public string Username { get; set; }
        public int ShippingMethodID { get; set; }
        public int PaymentTypeID { get; set; }
        public string Note { get; set; }
    
    }
}
