using Shared.Kernel.Abstractions;

namespace Delivery.Contract.IntegrationEvent;

public class DeliveryCompletedIntegrationEvent : IIntegrationEvent
{
    public Guid DeliveryId { get; init; }
    public Guid OrderId { get; init; }
}