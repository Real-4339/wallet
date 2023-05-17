using Application.Auth.Commands.Register;
using Application.Auth.Queries.Login;
using Microsoft.AspNetCore.Mvc;
using Dtos.Authentication;
using MediatR;

namespace Api.Controllers;

[Route("auth")]
public class AuthController : ApiController
{
    private readonly ISender _mediator;

    public AuthController(
        ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {   
        var command = new RegisterCommand(
            request.firstName, 
            request.lastName, 
            request.Email,
            request.Username, 
            request.Password
        );
        var authRegResult = await _mediator.Send(command);

        var response = new RegisterResponse(
            authRegResult.User.Id,
            authRegResult.User.Username, 
            authRegResult.Token
        );

        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authLogResult = await _mediator.Send(new LoginQuery(
            request.Username, 
            request.Password
        ));

        var response = new LoginResponse(
            authLogResult.Status
        );

        return Ok(response);
    }
}