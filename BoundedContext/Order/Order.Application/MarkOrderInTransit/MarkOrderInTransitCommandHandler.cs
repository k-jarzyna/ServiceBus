using NServiceBus;
using Order.Application.CompleteOrder;
using Order.Domain.Order;

namespace Order.Application.MarkOrderInTransit;

public class MarkOrderInTransitCommandHandler : IHandleMessages<CompleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public MarkOrderInTransitCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task Handle(CompleteOrderCommand message, IMessageHandlerContext context)
    {
        var orderAggregate = await _orderRepository.FindById(message.OrderId);

        if (orderAggregate is null)
        {
            throw new Exception("Order not found");
        }
        
        orderAggregate.InTransit();

        await _orderRepository.Persist(orderAggregate);
    }
}