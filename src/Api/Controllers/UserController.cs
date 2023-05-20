using Application.Users.Queries.Transactions;
using Application.Users.Commands.Wallet;
using Application.Users.Queries.Balance;
using Microsoft.AspNetCore.Mvc;
using Dtos.User.Transactions;
using Dtos.User.Balance;
using Dtos.User.Wallet;
using MapsterMapper;
using Dtos.User;
using MediatR;

namespace Api.Controllers;

[Route("users/{userId}/wallet")]
public class UserController : ApiController
{   
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(
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

    [HttpGet]
    [Route("balance")]
    public async Task<IActionResult> Get(
        GetBalanceRequest request,
        Guid userId)
    {   
        var query = new GetBalanceQuery(userId);
        var walletResult = await _mediator.Send(query);

        return Ok(_mapper.Map<GetBalanceResponse>(walletResult));
    }

    [HttpGet]
    [Route("transactions")]
    public async Task<IActionResult> Get(
        GetTxRequest request,
        Guid userId)
    {   
        var query = new GetTxQuery(
            userId,
            request.TxTypes
        );
        var txResult = await _mediator.Send(query);

        return Ok(_mapper.Map<GetTxResponse>(txResult));
    }
}