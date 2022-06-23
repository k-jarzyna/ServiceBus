using Delivery.Contract.IntegrationEvent;
using Delivery.Domain.Delivery;
using NServiceBus;

namespace Delivery.Application.CreateDeliveryAsync;

public class DeliveryCreatedDomainEventHandler : IHandleMessages<DeliveryCreatedDomainEvent>
{
    public async Task Handle(DeliveryCreatedDomainEvent message, IMessageHandlerContext context)
    {
        await context.Publish(new DeliveryCreatedIntegrationEvent()
        {
            OrderId = message.OrderId,
            DeliveryId = message.DeliveryId
        });
    }
}