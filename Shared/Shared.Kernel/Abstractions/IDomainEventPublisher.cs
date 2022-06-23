namespace Shared.Kernel.Abstractions;

public interface IDomainEventPublisher
{
    public Task Publish(IDomainEvent domainEvent);
}