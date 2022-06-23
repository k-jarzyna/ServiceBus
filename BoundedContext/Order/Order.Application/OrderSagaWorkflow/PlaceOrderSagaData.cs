using NServiceBus;

namespace Order.Application.OrderSagaWorkflow;

public class PlaceOrderSagaData : ContainSagaData
{
    public Guid OrderId { get; set; }
    
    public bool IsOrderPlaced { get; set; }
    
    public bool IsDeliveryScheduled { get; set; }
    
    public bool IsDeliveryCompleted { get; set; }
    
    public bool IsDeliveryCancelled { get; set; }
    
    public bool IsOrderCompleted { get; set; }
    
    public bool IsOrderCancelled { get; set; }
}