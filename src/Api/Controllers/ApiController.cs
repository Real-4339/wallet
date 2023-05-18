using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Authorize]
public abstract class ApiController : ControllerBase
{
    protected ApiController()
    {
    }
}