using Domain.User.Entities;

namespace Application.Auth.Common;

public record AuthRegResult(
    User User,
    string Token
);