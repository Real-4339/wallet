using Application.Common.Results;
using MediatR;

namespace Application.Users.Commands.Transactions;

public record CreditTxCommand(
    Guid UserId,
    Guid TxId,
    string Type,
    decimal Amount
) : IRequest<StatusResult>;