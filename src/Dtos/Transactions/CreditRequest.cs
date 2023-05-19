namespace Dtos.Transactions;

public record CreditRequest(
    string Type,
    decimal Amount
);