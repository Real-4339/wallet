namespace Dtos.User.Transactions;

public record GetTxResponse(
    Guid UserId,
    List<string> Transactions
);