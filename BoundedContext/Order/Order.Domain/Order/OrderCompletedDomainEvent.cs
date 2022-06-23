using Shared.Kernel.Abstractions;

namespace Order.Domain.Order;

public class OrderCompletedDomainEvent : IDomainEvent
{
    public Guid OrderId { get; init; }
}