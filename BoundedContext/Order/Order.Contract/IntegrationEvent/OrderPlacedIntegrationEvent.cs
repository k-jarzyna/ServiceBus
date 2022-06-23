using NServiceBus;
using Shared.Kernel.Abstractions;

namespace Order.Contract.IntegrationEvent;

public class OrderPlacedIntegrationEvent : IEvent
{
    public Guid OrderId { get; init; }
    
    public int CustomerId { get; init; }
    
    public List<int> Products { get; init; }
}