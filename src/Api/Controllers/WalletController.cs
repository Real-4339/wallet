using Application.Users.Commands.Wallet;
using Microsoft.AspNetCore.Mvc;
using Dtos.User.Wallet;
using MapsterMapper;
using MediatR;
using Dtos.User;

namespace Api.Controllers;

[Route("users/{userId}/wallet")]
public class WalletController : ApiController
{   
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public WalletController(
        ISender mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        RegisterWalletRequest request,
        Guid userId)
    {   
        var command = new RegisterWalletCommand(userId);
        var walletResult = await _mediator.Send(command);

        return Ok(_mapper.Map<RegisterWalletResponse>(walletResult));
    }
}