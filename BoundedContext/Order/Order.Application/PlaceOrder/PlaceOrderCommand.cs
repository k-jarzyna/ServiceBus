using MediatR;

namespace Order.Application.PlaceOrder;

public class PlaceOrderCommand : IRequest<Guid>
{
    public List<int> Products { get; init; }
    
    public int CustomerId { get; init; }
}