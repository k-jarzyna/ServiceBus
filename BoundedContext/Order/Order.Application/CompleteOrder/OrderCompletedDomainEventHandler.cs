using NServiceBus;
using Order.Contract.IntegrationEvent;
using Order.Domain.Order;

namespace Order.Application.CompleteOrder;

public class OrderCompletedDomainEventHandler : IHandleMessages<OrderCompletedDomainEvent>
{
    public async Task Handle(OrderCompletedDomainEvent message, IMessageHandlerContext context)
    {
        await context.Publish(new OrderCompletedIntegrationEvent()
        {
            OrderId = message.OrderId
        });
    }
}