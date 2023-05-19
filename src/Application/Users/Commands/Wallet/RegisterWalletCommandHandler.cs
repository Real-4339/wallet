using Application.Common.Results;
using MediatR;

namespace Application.Users.Commands.Wallet;

public class RegisterWalletCommandHandler : IRequestHandler<RegisterWalletCommand, StatusResult>
{
    public Task<StatusResult> Handle(RegisterWalletCommand command, CancellationToken cancellationToken)
    {
        // Create wallet
        // Add wallet to user
        // Return status result
        throw new NotImplementedException();
    }
}