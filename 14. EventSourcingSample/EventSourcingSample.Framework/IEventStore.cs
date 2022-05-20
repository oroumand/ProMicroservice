namespace EventSourcingSample.Framework;
public interface IEventStore
{
    void Save(string aggregateTypeName, long id,int currentVersion, IReadOnlyList<IDomainEvent> domainEvents);
    IReadOnlyList<IDomainEvent> Get(string aggregateTypeName, long id);
}
