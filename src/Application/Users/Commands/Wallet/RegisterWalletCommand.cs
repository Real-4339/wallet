using Application.Common.Results;
using MediatR;

namespace Application.Users.Commands.Wallet;

public record RegisterWalletCommand(
    Guid UserId
) : IRequest<StatusResult> ;