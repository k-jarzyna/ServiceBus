using NServiceBus;

namespace Shared.Kernel.Abstractions;

public class AggregateRoot
{
    public Guid Id { get; protected set; }
    
    protected List<IDomainEvent> DomainEvents = new List<IDomainEvent>();

    public async Task Commit(IDomainEventPublisher publisher)
    {
        DomainEvents.ForEach(domainEvent => publisher.Publish(domainEvent));
        
        DomainEvents.Clear();
    }

    public async Task CommitAsync(IMessageHandlerContext context)
    {
        DomainEvents.ForEach(domainEvent => context.Publish(domainEvent));
        
        DomainEvents.Clear();
    }

    protected void Add(IDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }
}