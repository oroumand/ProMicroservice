namespace ValueObject.Framework;

public abstract class BaseValueObjectV2<TValueObject> : IEquatable<TValueObject>
    where TValueObject : BaseValueObjectV2<TValueObject>
{
    public bool Equals(TValueObject? other)
        => this == other;
    public override bool Equals(object? obj)
    {
        return (obj is TValueObject otherObject) &&
            GetEqualityComponents().SequenceEqual(otherObject.GetEqualityComponents());
    }
    public abstract IEnumerable<object> GetEqualityComponents();
    public override int GetHashCode()
        => GetEqualityComponents().Select(c => c != null ? c.GetHashCode() : 0).Aggregate((x, y) => x ^ y);

    public static bool operator ==(BaseValueObjectV2<TValueObject> left, BaseValueObjectV2<TValueObject> right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }


    public static bool operator !=(BaseValueObjectV2<TValueObject> left, BaseValueObjectV2<TValueObject> right)
    => !(left == right);

}
