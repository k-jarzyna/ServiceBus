using Shared.Kernel.Abstractions;

namespace Order.Contract.IntegrationEvent;

public class OrderCompletedIntegrationEvent : IIntegrationEvent
{
    public Guid OrderId { get; init; }
}