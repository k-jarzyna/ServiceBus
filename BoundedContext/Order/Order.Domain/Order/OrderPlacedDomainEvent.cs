using NServiceBus;
using Shared.Kernel.Abstractions;

namespace Order.Domain.Order;

public class OrderPlacedDomainEvent : IDomainEvent
{
    public Guid OrderId { get; init; }
    
    public int CustomerId { get; init; }
    
    public List<int> Products { get; init; }
}