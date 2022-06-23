using NServiceBus;
using Order.Message;
using Order.Contract.IntegrationEvent;
using Order.Domain.Order;
using Shared.Kernel.Abstractions;

namespace Order.Application.PlaceOrderAsync;

public class PlaceOrderAsyncCommandHandler : IHandleMessages<PlaceOrderRequest>
{
    private readonly IOrderRepository _orderRepository;

    public PlaceOrderAsyncCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task Handle(PlaceOrderRequest message, IMessageHandlerContext context)
    {
        var orderAggregate = OrderAggregateRoot.Place(message.CustomerId, message.Products);
        await _orderRepository.Persist(orderAggregate);
        await orderAggregate.CommitAsync(context);
        
        await context.Reply(new OrderPlacedResponse()
        {
            OrderId = orderAggregate.Id,
            Products = orderAggregate.Products,
            CustomerId = orderAggregate.CustomerId
        });
    }
}