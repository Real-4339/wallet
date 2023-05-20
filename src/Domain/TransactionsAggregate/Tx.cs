using Domain.TransactionsAggregate.ValueObjects;
using Domain.TransactionsAggregate.Enums;
using Domain.UserAggregate.ValueObjects;
using System.Text.Json.Serialization;
using Domain.Common.Primitives;
using System.Text.Json;

namespace Domain.TransactionsAggregate;

public sealed class Tx : AggregateRoot<TxId>
{
    public UserId UserId { get; init; }
    public decimal Amount { get; init; }
    public TransactionType Type { get; init; }
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

    public static Tx Create(
        UserId userId,
        TxId txId,
        decimal amount,
        TransactionType type,
        TransactionState state) =>
        new(txId, userId, amount, type, state);

    public void UpdateState(TransactionState state){
        State = state;
    }

    public string Serialize(){
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };

        return JsonSerializer.Serialize(this, options);
    }
}
    