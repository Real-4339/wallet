using MediatR;

namespace Application.Users.Queries.Transactions;

public record GetTxQuery(
    Guid UserId,
    List<string> Types
) : IRequest<GetTxResult>;