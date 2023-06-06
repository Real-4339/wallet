using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.UserAggregate;
using MediatR;

namespace Application.Users.Commands.Wallet;

public class RegisterWalletCommandHandler : IRequestHandler<RegisterWalletCommand, StatusResult>
{   
    private readonly IUserRepo _authRepository;
    private readonly ISemaphoreRepo _semaphore;

    public RegisterWalletCommandHandler(
        IUserRepo authRepository,
        ISemaphoreRepo semaphore)
    {   
        _authRepository = authRepository;
        _semaphore = semaphore;
    }

    public async Task<StatusResult> Handle(RegisterWalletCommand command, CancellationToken cancellationToken)
    {   
        // Find user
        if (await _authRepository.GetUserByIdAsync(command.UserId) is not User user)
        {   
            throw new Exception("Internal Server Error");
        }

        // Register wallet
        await _semaphore.WalletWaitAsync();
        user.RegisterWallet(0);
        _semaphore.WalletSemaphore.Release();
        
        // Return status result
        return new StatusResult("success");
    }
}