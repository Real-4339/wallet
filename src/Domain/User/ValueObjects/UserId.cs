using Domain.Common.Primitives;

namespace Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{   
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId New() => new(Guid.NewGuid());

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}