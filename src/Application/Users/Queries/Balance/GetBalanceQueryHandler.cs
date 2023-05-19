using Application.Common.Interfaces.Persistence;
using Domain.UserAggregate;
using MediatR;

namespace Application.Users.Queries.Balance;

public class BalanceQueryHandler : IRequestHandler<GetBalanceQuery, GetBalanceResult>
{
    private readonly IUserRepo _authRepository;

    public BalanceQueryHandler(
        IUserRepo authRepository
        )
    {   
        _authRepository = authRepository;
    }

    public async Task<GetBalanceResult> Handle(GetBalanceQuery query, CancellationToken cancellationToken)
    {   
        await Task.CompletedTask;

        // Find user
        if (_authRepository.GetUserById(query.UserId) is not User user)
        {   
            throw new Exception("Internal Server Error");
        }

        // Return balance result
        return new GetBalanceResult(user.Id.Value, user.GetBalance());
    }
}