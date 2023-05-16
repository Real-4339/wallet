namespace Wallet.Dtos.Authentication;

public record RegisterRequest(
    string firstName,
    string lastName,
    string Email,
    string Username,
    string Password
);