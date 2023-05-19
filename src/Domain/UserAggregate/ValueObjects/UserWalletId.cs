using Domain.Common.Primitives;

namespace Domain.UserAggregate.ValueObjects;

public sealed class UserWalletId : ValueObject
{
    private UserWalletId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static UserWalletId New() => new(Guid.NewGuid());

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
} 