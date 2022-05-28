using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;

namespace CQRSSamples.Framework;
public class BaseCommandDbContext : DbContext
{
    public BaseCommandDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }


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
    }

    private void AddToOutBox()
    {
        var entities = ChangeTracker
                    .Entries<AggregateRoot>()
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

    public IEnumerable<string> GetIncludePaths(Type clrEntityType)
    {
        var entityType = Model.FindEntityType(clrEntityType);
        var includedNavigations = new HashSet<INavigation>();
        var stack = new Stack<IEnumerator<INavigation>>();
        while (true)
        {
            var entityNavigations = new List<INavigation>();
            foreach (var navigation in entityType.GetNavigations())
            {
                if (includedNavigations.Add(navigation))
                    entityNavigations.Add(navigation);
            }
            if (entityNavigations.Count == 0)
            {
                if (stack.Count > 0)
                    yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
            }
            else
            {
                foreach (var navigation in entityNavigations)
                {
                    var inverseNavigation = navigation.Inverse;
                    if (inverseNavigation != null)
                        includedNavigations.Add(inverseNavigation);
                }
                stack.Push(entityNavigations.GetEnumerator());
            }
            while (stack.Count > 0 && !stack.Peek().MoveNext())
                stack.Pop();
            if (stack.Count == 0) break;
            entityType = stack.Peek().Current.TargetEntityType;
        }
    }
}