using Shared.Kernel.Abstractions;

namespace Delivery.Domain.Delivery;

public class DeliveryAggregateRoot : AggregateRoot
{
    public enum DeliveryStatus
    {
        New, Completed, Cancelled
    }
    
    public Guid OrderId { get; private set; }
    
    public DeliveryStatus Status { get; private set; }

    public static DeliveryAggregateRoot Make(Guid orderId)
    {
        var aggregate = new DeliveryAggregateRoot()
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            Status = DeliveryStatus.New
        };

        return aggregate;
    }

    public void Cancel()
    {
        Status = DeliveryStatus.Cancelled;
    }

    public void Complete()
    {
        Status = DeliveryStatus.Completed;
    }
}