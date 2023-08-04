using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.General;

public class TokenRequest
{
    public string GrantType { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string RefreshToken { get; set; }
    public string Scope { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}

