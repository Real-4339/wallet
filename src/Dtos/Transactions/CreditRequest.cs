namespace Dtos.Transactions;

public record CreditRequest(
    Guid UserId,
    string Type,
    decimal Amount
);