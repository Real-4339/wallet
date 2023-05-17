using Domain.User.Entities;

namespace Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}