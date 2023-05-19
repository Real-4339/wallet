using Application.Common.Results;
using MediatR;

namespace Application.Users.Commands.Wallet;

public class RegisterWalletCommandHandler : IRequestHandler<RegisterWalletCommand, StatusResult>
{
    public Task<StatusResult> Handle(RegisterWalletCommand command, CancellationToken cancellationToken)
    {
        // Find user
        // Check if user already has a wallet
        // Register wallet
        // Return status result
        return Task.FromResult(new StatusResult("true"));
    }
}