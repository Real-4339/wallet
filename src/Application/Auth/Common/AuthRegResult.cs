using Domain.UserAggregate;

namespace Application.Auth.Common;

public record AuthRegResult(
    User User,
    string Token
);