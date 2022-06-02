using Earth.Core.Domain.Events;

namespace Earth.Core.Contracts.ApplicationServices.Events;

public interface IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}
