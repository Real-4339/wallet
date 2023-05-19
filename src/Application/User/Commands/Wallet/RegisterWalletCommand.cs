namespace Application.UserAggregate.Commands.Wallet;

public record RegisterWalletCommand(
    string Name,
    string Description,
    string Currency,
    string UserId
);