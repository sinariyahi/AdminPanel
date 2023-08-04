using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dto
{
    public class RefreshTokenDTO
    {
        public string RefreshToken { get; set; }
        public UserDTO User { get; set; }
    }
}
