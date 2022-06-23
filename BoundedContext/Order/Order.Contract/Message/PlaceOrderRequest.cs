using NServiceBus;

namespace Order.Message;

public class PlaceOrderRequest : IMessage
{
    public List<int> Products { get; init; }
    
    public int CustomerId { get; init; }
}