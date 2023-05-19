using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.UserAggregate;
using MediatR;

namespace Application.Users.Commands.Wallet;

public class RegisterWalletCommandHandler : IRequestHandler<RegisterWalletCommand, StatusResult>
{   
    private readonly IUserRepo _authRepository;

    public RegisterWalletCommandHandler(
        IUserRepo authRepository
        )
    {   
        _authRepository = authRepository;
    }

    public async Task<StatusResult> Handle(RegisterWalletCommand command, CancellationToken cancellationToken)
    {   
        await Task.CompletedTask;

        // Find user
        if (_authRepository.GetUserById(command.UserId) is not User user)
        {   
            throw new Exception("Internal Server Error");
        }
        // Register wallet
        user.RegisterWallet(0);

        // Return status result
        return new StatusResult("success");
    }
}