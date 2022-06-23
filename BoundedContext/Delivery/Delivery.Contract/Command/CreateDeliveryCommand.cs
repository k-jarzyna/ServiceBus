using NServiceBus;

namespace Delivery.Contract.Command;

public class CreateDeliveryCommand : ICommand
{
    public Guid OrderId { get; init; }
}