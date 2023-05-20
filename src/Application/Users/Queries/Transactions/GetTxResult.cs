namespace Application.Users.Queries.Transactions;

public record GetTxResult(
    Guid UserId,
    List<string> Transactions
);