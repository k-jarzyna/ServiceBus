using Shared.Kernel.Abstractions;

namespace Order.Domain.Order;

public class OrderCancelledDomainEvent : IDomainEvent
{
    public Guid OrderId { get; init; }
}