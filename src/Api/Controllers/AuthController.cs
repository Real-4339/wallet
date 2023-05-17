using Microsoft.AspNetCore.Mvc;
using Application.Services.Auth;
using Dtos.Authentication;

namespace Api.Controllers;


[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {   
        var authRegResult = _authService.Register(
            request.firstName, 
            request.lastName, 
            request.Email, 
            request.Username, 
            request.Password
        );

        var response = new RegisterResponse(
            authRegResult.User.Id,
            authRegResult.User.Username, 
            authRegResult.Token
        );

        return Ok(response);
    }
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authLogResult = _authService.Login(
            request.Username, 
            request.Password
        );

        var response = new LoginResponse(
            authLogResult.Status
        );

        return Ok(response);
    }
}