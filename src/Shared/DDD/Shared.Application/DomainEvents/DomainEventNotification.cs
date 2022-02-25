namespace Ted.Shared.Application.DomainEvents;

public class DomainEventNotification<TDomainEvent>
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    public TDomainEvent DomainEvent { get; }
}