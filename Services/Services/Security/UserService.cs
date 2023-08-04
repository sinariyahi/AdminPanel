using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.User;
using Domain.Models.Dto;
using InfraStructure.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using Services.Interface.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Security;
public class UserService : IUserService,IBaseSevice
{
    private readonly UserManager<User> _userManager;
    private readonly IRepository<User> _userRepository;
    protected readonly IMapper _mapper;
    public UserService(UserManager<User> userManager, IRepository<User> userRepository,IMapper mapper)
    {
        _userManager = userManager;        
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User> FindUserByUserName(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        //if (user == null)
        //    throw new BadRequestException(errorUser);
        //if (!user.IsActive)
        //    throw new BadRequestException(errorUser);
        //var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
        //if (!isPasswordValid)
        //    throw new BadRequestException(errorUser);
        return user;

    }
    public async Task<User> AddAsync(User user,string password, CancellationToken cancellationToken)
    {
        await _userManager.CreateAsync(user,password);
        return user;
    }
    public async Task<PagedList<UserGridView>> GetAll(int pageNumber, int pageSize, string name, CancellationToken cancellationToken)
    {
        var outPut = new PagedList<UserGridView>();
        var t = _userRepository.TableNoTracking.Where(x => x.UserName.Contains(name)).OrderByDescending(d => d.Id);
        outPut.TotalCount = await t.CountAsync();
        outPut.list = await t.Skip(pageNumber * pageSize).Take(pageSize).ProjectTo<UserGridView>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        return outPut;
    }
    public async Task<User> FindByIdAsync( int id, CancellationToken cancellationToken)
    {
        var user= await _userRepository.GetByIdAsync(cancellationToken, id);
        return user;
    }

    public async Task<IList<string>> GetUserRoles(User user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}

