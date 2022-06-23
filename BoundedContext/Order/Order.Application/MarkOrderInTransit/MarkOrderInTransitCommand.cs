using NServiceBus;

namespace Order.Application.MarkOrderInTransit;

public class MarkOrderInTransitCommand : ICommand
{
    public Guid OrderId { get; init; }
}