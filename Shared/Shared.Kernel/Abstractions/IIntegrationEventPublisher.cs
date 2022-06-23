namespace Shared.Kernel.Abstractions;

public interface IIntegrationEventPublisher
{
    public Task Publish(IIntegrationEvent integrationEvent);
}