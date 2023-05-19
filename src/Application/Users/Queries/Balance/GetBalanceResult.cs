namespace Application.Users.Queries.Balance;

public record GetBalanceResult(
    Guid UserId,
    decimal Balance
);