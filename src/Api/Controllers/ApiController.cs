using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected ApiController()
    {
    }
}