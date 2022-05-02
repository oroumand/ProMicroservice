using DomainEventsSamples.Core.Domain.People;
using DomainEventsSamples.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace DomainEventsSamples.Infra.Dal;
public class SampleContext:DbContext
{
    public SampleContext(DbContextOptions<SampleContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    public override int SaveChanges()
    {
        HandleBeforSaveChanges();
        return base.SaveChanges();
    }



    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        HandleBeforSaveChanges();

        return base.SaveChangesAsync(cancellationToken);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        HandleBeforSaveChanges();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        HandleBeforSaveChanges();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    private void HandleBeforSaveChanges()
    {
        AddToOutBox();
        DispatchEvents();
    }

    private void AddToOutBox()
    {
        var entities = ChangeTracker
                    .Entries<Entity>()
                    .Where(c => c.State == EntityState.Added || c.State == EntityState.Modified)
                    .Select(c => c.Entity).ToList();
        var dateTime = DateTime.Now;
        foreach (var item in entities)
        {
            foreach (var @event in item.Events)
            {
                OutBoxEventItems.Add(new OutBoxEventItem
                {
                    EventId = Guid.NewGuid(),
                    AccuredByUserId = "1",
                    AccuredOn = dateTime,
                    AggregateId = "1",
                    AggregateName = item.GetType().Name,
                    AggregateTypeName = item.GetType().FullName,
                    EventName = @event.GetType().Name,
                    EventTypeName = @event.GetType().FullName,
                    EventPayload = JsonConvert.SerializeObject(@event),
                    IsProcessed = false
                });
            }
        }
    }

    private void DispatchEvents()
    {
        var dispatcher = this.GetService<IDomainEventDispatcher>();

        var entities = ChangeTracker
            .Entries<Entity>()
            .Where(c=>c.State == EntityState.Added || c.State == EntityState.Modified)
            .Select(c=>c.Entity).ToList();

        foreach (var entity in entities)
        {
            dispatcher.Dispatch(entity.Events);
            entity.ClearEvent();
        }


    }

    public DbSet<Person> People{ get; set; }
    public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }
}
