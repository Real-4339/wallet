using Microsoft.AspNetCore.Authorization;
using Application.Auth.Commands.Register;
using Application.Auth.Queries.Login;
using Microsoft.AspNetCore.Mvc;
using Dtos.Authentication;
using MapsterMapper;
using MediatR;

namespace Api.Controllers;

[AllowAnonymous]
[Route("auth")]
public class AuthController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(
        ISender mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {   

        var command = _mapper.Map<RegisterCommand>(request);
        var authRegResult = await _mediator.Send(command);

        return Ok(_mapper.Map<RegisterResponse>(authRegResult));
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authLogResult = await _mediator.Send(_mapper.Map<LoginQuery>(request));

        return Ok(_mapper.Map<LoginResponse>(authLogResult));
    }
}