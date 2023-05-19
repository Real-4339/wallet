namespace Dtos.User.Balance;

public record GetBalanceResponse(
    Guid UserId,
    decimal Balance
);