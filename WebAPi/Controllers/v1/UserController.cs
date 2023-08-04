using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.User;
using Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Security;

namespace WebAPi.Controllers.v1;
public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;   
    public UserController(IUserService userService,IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<PagedList<UserGridView>> Index(CancellationToken cancellationToken, string userName, int pageNumber = 0, int pagesize = 10)
    {
        return await _userService.GetAll(pageNumber, pagesize, userName, cancellationToken);
    }
    [HttpPost("create")]
    public async Task<ActionResult<UserDTO>> Post(UserDTO user, CancellationToken cancellationToken)
    {
        var userModel = _mapper.Map<User>(user);
        return Ok(await _userService.AddAsync(userModel,user.Password, cancellationToken));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id, CancellationToken cancellationToken)
    {
        return Ok(await _userService.FindByIdAsync(id, cancellationToken));
    }
}

