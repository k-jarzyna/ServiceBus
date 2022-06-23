using NServiceBus;
using Order.Contract.IntegrationEvent;
using Order.Domain.Order;

namespace Order.Application.PlaceOrderAsync;

public class OrderPlacedDomainEventListener : IHandleMessages<OrderPlacedDomainEvent>
{
    public async Task Handle(OrderPlacedDomainEvent message, IMessageHandlerContext context)
    {
        await context.Publish(new OrderPlacedIntegrationEvent()
        {
            CustomerId = message.CustomerId,
            Products = message.Products,
            OrderId = message.OrderId
        });
    }
}