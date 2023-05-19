using Application.Common.Results;
using MediatR;

namespace Application.UserAggregate.Commands.Wallet;

public record RegisterWalletCommand() : IRequest<StatusResult> ;