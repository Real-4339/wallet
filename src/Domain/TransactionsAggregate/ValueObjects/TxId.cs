using Domain.Common.Primitives;

namespace Domain.TransactionsAggregate.ValueObjects;

public sealed class TxId : ValueObject
{
    public Guid Value { get; }

    private TxId(Guid value)
    {
        Value = value;
    }

    public static TxId New() => new(Guid.NewGuid());

    public static TxId From(Guid value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}