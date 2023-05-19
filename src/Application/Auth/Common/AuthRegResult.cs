using Domain.User;

namespace Application.Auth.Common;

public record AuthRegResult(
    User User,
    string Token
);