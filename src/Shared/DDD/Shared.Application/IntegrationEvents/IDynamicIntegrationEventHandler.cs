namespace Ted.Shared.Application.IntegrationEvents;

public interface IDynamicIntegrationEventHandler
{
    Task Handle(dynamic eventData);
}