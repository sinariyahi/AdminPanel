using Domain.Common;
using Domain.Entities.User;
using Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface.Security;
public interface IUserService
{
    Task<User> FindUserByUserName(string userName, string password);
    Task<IList<string>> GetUserRoles(User user);
    //Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);
    Task<User> AddAsync(User user, string password, CancellationToken cancellationToken);
    //Task UpdateSecurityStampAsync(User user, CancellationToken cancellationToken);
    // Task UpdateLastLoginDateAsync(User user, CancellationToken cancellationToken);
    Task<PagedList<UserGridView>> GetAll(int pageNumber, int pageSize, string name, CancellationToken cancellationToken);
    Task<User> FindByIdAsync( int id, CancellationToken cancellationToken);
}

