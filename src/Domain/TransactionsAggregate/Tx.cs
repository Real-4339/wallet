using Domain.TransactionsAggregate.ValueObjects;
using Domain.TransactionsAggregate.Enums;
using Domain.UserAggregate.ValueObjects;
using Domain.Common.Primitives;

namespace Domain.TransactionsAggregate;

public sealed class Tx : AggregateRoot<TxId>
{
    public UserId UserId { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public TransactionState State { get; private set; }
    
    private Tx(
        TxId id, 
        UserId userId,
        decimal amount,
        TransactionType type,
        TransactionState state)
        : base(id)
    {
        UserId = userId;
        Type = type;
        Amount = amount;
        State = state;
    }

    public static Tx Create(
        UserId userId,
        decimal amount,
        TransactionType type,
        TransactionState state) =>
        new(TxId.New(), userId, amount, type, state);
}
    