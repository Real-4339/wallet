using Domain.User.Entities;

namespace Application.Services.Auth;

public record AuthRegResult(
    User User,
    string Token
);