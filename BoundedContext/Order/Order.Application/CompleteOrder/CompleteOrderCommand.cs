using NServiceBus;

namespace Order.Application.CompleteOrder;

public class CompleteOrderCommand : ICommand
{
    public Guid OrderId { get; init; }
}