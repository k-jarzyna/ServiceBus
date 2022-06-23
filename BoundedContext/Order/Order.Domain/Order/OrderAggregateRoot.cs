using Shared.Kernel.Abstractions;

namespace Order.Domain.Order;

public class OrderAggregateRoot : AggregateRoot
{
    
    public enum OrderStatus
    {
        New, InTransit, Cancelled, Completed
    }
    
    public int CustomerId { get; private set; }
    
    public List<int> Products { get; private set; }
    
    public OrderStatus Status { get; private set;  }

    public static OrderAggregateRoot Place(int CustomerId, List<int> Products)
    {
        var aggregate = new OrderAggregateRoot()
        {
            Id = Guid.NewGuid(),
            CustomerId = CustomerId,
            Products = Products,
            Status = OrderStatus.New
        };
        
        aggregate.Add(new OrderPlacedDomainEvent()
        {
            OrderId = aggregate.Id,
            Products = aggregate.Products,
            CustomerId = aggregate.CustomerId
        });

        return aggregate;
    }

    public void InTransit()
    {
        Status = OrderStatus.InTransit;
    }

    public void Complete()
    {
        Status = OrderStatus.Completed;
        
        Add(new OrderCompletedDomainEvent()
        {
            OrderId = Id
        });
    }

    public void Cancel()
    {
        Status = OrderStatus.Cancelled;
        
        Add(new OrderCancelledDomainEvent()
        {
            OrderId = Id
        });
    }
}