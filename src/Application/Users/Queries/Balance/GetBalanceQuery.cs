using MediatR;

namespace Application.Users.Queries.Balance;

public record GetBalanceQuery(
    Guid UserId
) : IRequest<GetBalanceResult>;