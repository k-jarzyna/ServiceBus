using NServiceBus;
using Order.Domain.Order;

namespace Order.Application.CompleteOrder;

public class CompleteOrderCommandHandler : IHandleMessages<CompleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public CompleteOrderCommandHandler(IOrderRepository orderRepository)
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
        
        orderAggregate.Complete();

        await _orderRepository.Persist(orderAggregate);
        await orderAggregate.CommitAsync(context);
    }
}