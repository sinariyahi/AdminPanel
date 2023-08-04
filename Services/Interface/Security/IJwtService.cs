using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface.Security
{
    public interface IJwtService
    {
        Task<AccessToken> GenerateAsync(User user,string roles);
    }
}
