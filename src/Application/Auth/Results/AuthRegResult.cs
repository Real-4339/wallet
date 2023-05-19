using Domain.UserAggregate;

namespace Application.Auth.Results;

public record AuthRegResult(
    User User,
    string Token
);