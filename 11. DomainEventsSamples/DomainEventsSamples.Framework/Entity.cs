namespace DomainEventsSamples.Framework;

public class Entity : IEquatable<Entity>
{
    public long Id { get; set; }
    private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

    public IReadOnlyList<IDomainEvent> Events => _events;
    protected void AddEvent(IDomainEvent @event)
    {
        _events.Add(@event);
    }

    public void ClearEvent()
    {
        _events.Clear();
    }
    #region Equality Check
    public bool Equals(Entity? other)
    => this == other;
    public override bool Equals(object? obj)
    {
        return (obj is Entity otherObject) && this.Id == otherObject.Id;
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public static bool operator ==(Entity left, Entity right)
    {
        if (left is null && right is null)
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
        => !(right == left);

    #endregion
}

