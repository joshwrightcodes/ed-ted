using Ted.Shared.Domain.Events;

namespace Ted.Shared.Application.DomainEvents;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}