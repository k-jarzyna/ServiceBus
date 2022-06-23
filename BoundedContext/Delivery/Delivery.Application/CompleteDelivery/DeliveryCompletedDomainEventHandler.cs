using Delivery.Contract.IntegrationEvent;
using Delivery.Domain.Delivery;
using NServiceBus;

namespace Delivery.Application.CompleteDelivery;

public class DeliveryCompletedDomainEventHandler : IHandleMessages<DeliveryCompletedDomainEvent>
{
    public async Task Handle(DeliveryCompletedDomainEvent message, IMessageHandlerContext context)
    {
        await context.Publish(new DeliveryCompletedIntegrationEvent()
        {
            DeliveryId = message.DeliveryId,
            OrderId = message.OrderId
        });
    }
}