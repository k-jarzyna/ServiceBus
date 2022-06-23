using Shared.Kernel.Abstractions;

namespace Delivery.Contract.IntegrationEvent;

public class DeliveryCreatedIntegrationEvent : IIntegrationEvent
{
    public Guid DeliveryId { get; init; }
    
    public Guid OrderId { get; init; }
}