namespace Dtos.Authentication;

public record RegisterResponse(
    Guid id,
    string Username,
    string Token
);