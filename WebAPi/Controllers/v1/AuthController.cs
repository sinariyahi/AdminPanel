using Domain.Models.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Security;

namespace WebAPi.Controllers.v1;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;
    public AuthController(IJwtService jwtService, IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }
    [AllowAnonymous]
    [HttpPost(Name = "GetToken")]
    public async Task<ActionResult> GetToken(TokenRequest tokenRequest, CancellationToken cancellationToken)
    {
        if (!tokenRequest.GrantType.Equals("password", StringComparison.OrdinalIgnoreCase))
            throw new Exception("OAuth flow is not password.");
        var user = await _userService.FindUserByUserName(tokenRequest.UserName, tokenRequest.Password);
        var roles = await _userService.GetUserRoles(user);
        string rolesStr = string.Join(",", roles);
        var jwt = await _jwtService.GenerateAsync(user, rolesStr);
        return Ok(jwt);
    }
}

