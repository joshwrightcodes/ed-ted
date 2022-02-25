namespace Ted.Shared.Application.IntegrationEvents;

public interface IIntegrationEventHandler
{
}

public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @event);
}
