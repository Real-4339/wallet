namespace Wallet.Dtos.Authentication;

public record LoginRequest(
    string Username,
    string Password
);