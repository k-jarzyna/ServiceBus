using Shared.Kernel.Abstractions;

namespace Delivery.Domain.Delivery;

public class DeliveryCompletedDomainEvent : IDomainEvent
{
    public Guid DeliveryId { get; init; }
    public Guid OrderId { get; init; }
}