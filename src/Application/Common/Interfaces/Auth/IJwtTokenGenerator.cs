using Domain.UserAggregate;

namespace Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}