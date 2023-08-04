using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPi.Controllers.v1;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : ControllerBase
{
}

