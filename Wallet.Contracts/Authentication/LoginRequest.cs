namespace Wallet.Contracts.Authentication;

public record LoginRequest(
    string username,
    string password
);