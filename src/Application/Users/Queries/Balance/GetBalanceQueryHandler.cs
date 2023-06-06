using Application.Common.Interfaces.Persistence;
using Domain.UserAggregate;
using MediatR;

namespace Application.Users.Queries.Balance;

public class BalanceQueryHandler : IRequestHandler<GetBalanceQuery, GetBalanceResult>
{
    private readonly IUserRepo _authRepository;
    private readonly ISemaphoreRepo _semaphore;

    public BalanceQueryHandler(
        IUserRepo authRepository,
        ISemaphoreRepo semaphore)
    {   
        _authRepository = authRepository;
        _semaphore = semaphore;
    }

    public async Task<GetBalanceResult> Handle(GetBalanceQuery query, CancellationToken cancellationToken)
    {   
        // Find user
        if (await _authRepository.GetUserByIdAsync(query.UserId) is not User user)
        {
            throw new Exception("Internal Server Error");
        }

        await _semaphore.WalletWaitAsync();
        var balance = user.GetBalance();
        _semaphore.WalletSemaphore.Release();

        // Return balance result
        return new GetBalanceResult(user.Id.Value, balance);
    }
}