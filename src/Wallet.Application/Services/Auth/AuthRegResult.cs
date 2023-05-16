using Wallet.Domain.User.Entities;

namespace Wallet.Application.Services.Auth;

public record AuthRegResult(
    User User,
    string Token
);