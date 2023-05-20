namespace Dtos.Transactions;

public record CreditRequest(
    string TxId,
    string Type,
    decimal Amount
);