using MediatR;
using Shared.Kernel.Abstractions;

namespace Shared.Infrastructure.Adapters;

public class DomainEventPublisherAdapter : IDomainEventPublisher
{
    private readonly IMediator _mediator;

    public DomainEventPublisherAdapter(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task Publish(IDomainEvent domainEvent)
    {
        await _mediator.Publish(domainEvent);
    }
}