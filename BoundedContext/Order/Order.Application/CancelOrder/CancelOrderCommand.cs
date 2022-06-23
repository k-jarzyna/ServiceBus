using NServiceBus;

namespace Order.Application.CancelOrder;

public class CancelOrderCommand : ICommand
{
    public Guid OrderId { get; init; }
}