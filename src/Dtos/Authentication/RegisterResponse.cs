namespace Dtos.Authentication;

public record RegisterResponse(
    Guid Id,
    string Username,
    string Token
);