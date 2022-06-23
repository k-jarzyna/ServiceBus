using NServiceBus;

namespace Delivery.Contract.Command;

public class CompleteDeliveryCommand : ICommand
{
    public Guid DeliveryId { get; init; }
}