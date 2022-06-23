using NServiceBus;
using Shared.Kernel.Abstractions;

namespace Order.Message;

public class OrderPlacedResponse : IMessage
{
    public Guid OrderId { get; init; }
    
    public int CustomerId { get; init; }
    
    public List<int> Products { get; init; }
}