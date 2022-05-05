using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatesSamples.Framework;
public interface IDomainEventDispatcher
{
    Task Dispatch(IEnumerable<IDomainEvent> events);
}

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _services;

    public DomainEventDispatcher(IServiceProvider _services )
    {
        this._services = _services;
    }
    public Task Dispatch(IEnumerable<IDomainEvent> events)
    {
        foreach (dynamic @event in events)
        {
            DispatchEvent(@event);
        }
       return Task.CompletedTask;
    }

    private async Task DispatchEvent<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent
    {
        var type = typeof(TDomainEvent);
        var handlers = _services.GetServices<IDomainEventHandler<TDomainEvent>>();

        foreach (var handler in handlers)
        {
            handler.Hanlde(@event);
        }
    }
}