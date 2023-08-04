using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class AccountPageDTO
    {
        public UserDTO User { get; set; }
        public AddressDTO Address { get; set; }
    }
}
