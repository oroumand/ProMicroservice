namespace CQRSSamples.Framework;
public interface ICommandRepository<TAggregate> where TAggregate : AggregateRoot
{
    TAggregate Get(long id);
    void SaveChanges();
    Task SaveChangesAsync();
}
