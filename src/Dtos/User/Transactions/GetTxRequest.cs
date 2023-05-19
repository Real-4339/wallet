namespace Dtos.User.Transactions;

public record GetTxRequest(
    Guid UserId,
    List<string> TxTypes
);