using Wallets.Domain.User.Entities;

namespace Wallet.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}