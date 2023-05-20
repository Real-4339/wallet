using Application.Users.Commands.Transactions;
using Microsoft.AspNetCore.Mvc;
using Dtos.Transactions;
using MapsterMapper;
using MediatR;

namespace Api.Controllers;

[Route("/transactions/credit/{userId}")]
public class TxController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public TxController(
        ISender mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Credit(
        CreditRequest request,
        Guid userId)
    {   

        var command = new CreditTxCommand(
            userId,
            request.Type,
            request.Amount);

        var txResult = await _mediator.Send(command);

        return Ok(_mapper.Map<CreditResponse>(txResult));
    }
}