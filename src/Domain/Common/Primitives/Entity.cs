namespace Domain.Common.Primitives;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    protected Entity(TId id)
    {
        Id = id;
    }

    public TId Id { get; protected set; } = default!;

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (Entity<TId>)obj;
        return Equals(other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity<TId>? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return EqualOperator(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return NotEqualOperator(left, right);
    }

    protected static bool EqualOperator(Entity<TId>? left, Entity<TId>? right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }

        return ReferenceEquals(left, null) || left.Equals(right);
    }

    protected static bool NotEqualOperator(Entity<TId>? left, Entity<TId>? right)
    {
        return !(EqualOperator(left, right));
    }
}