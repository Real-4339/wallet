namespace Dtos.User.Transactions;

public record GetTxRequest(
    List<string> TxTypes
);