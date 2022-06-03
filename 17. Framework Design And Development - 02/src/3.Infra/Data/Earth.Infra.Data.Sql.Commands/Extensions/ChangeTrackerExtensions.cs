using Earth.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth.Infra.Data.Sql.Commands.Extensions;

public static class ChangeTrackerExtensions
{
    public static List<AggregateRoot> GetChangedAggregates(this ChangeTracker changeTracker) =>
        changeTracker.Aggreates().Where(IsModified()).Select(c => c.Entity).ToList();

    public static List<AggregateRoot> GetAggregatesWithEvent(this ChangeTracker changeTracker) =>
            changeTracker.Aggreates()
            .Where(IsNotDetached()).Select(c => c.Entity).Where(c => c.GetEvents().Any()).ToList();
    public static IEnumerable<EntityEntry<AggregateRoot>> Aggreates(this ChangeTracker changeTracker) =>
        changeTracker.Entries<AggregateRoot>();

    private static Func<EntityEntry<AggregateRoot>, bool> IsNotDetached() =>
        x => x.State != EntityState.Detached;

    private static Func<EntityEntry<AggregateRoot>, bool> IsModified()
    {
        return x => x.State == EntityState.Modified ||
                                           x.State == EntityState.Added ||
                                           x.State == EntityState.Deleted;
    }

}