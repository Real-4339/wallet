using Domain.Common.Primitives;

namespace Domain.Transactions.ValueObjects;

public sealed class TxId : ValueObject
{
    public Guid Value { get; }

    private TxId(Guid value)
    {
        Value = value;
    }

    public static TxId New() => new(Guid.NewGuid());

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}