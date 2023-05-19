using Domain.Transactions.ValueObjects;
using Domain.UserAggregate.ValueObjects;
using Domain.Common.Primitives;

namespace Domain.Transactions;

public sealed class Tx : AggregateRoot<TxId>
{
    public UserId UserId { get; }
    public string Type { get; }
    public decimal Amount { get; }
    
    private Tx(
        TxId id, 
        UserId userId, 
        string type, 
        decimal amount)
        : base(id)
    {
        UserId = userId;
        Type = type;
        Amount = amount;
    }

    public static Tx Create(
        UserId userId, 
        string type, 
        decimal amount) => 
        new(TxId.New(), userId, type, amount);
}
    