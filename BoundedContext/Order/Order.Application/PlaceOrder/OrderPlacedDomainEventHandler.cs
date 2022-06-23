using MediatR;
using Order.Domain.Order;

namespace Order.Application.PlaceOrder;

public class OrderPlacedDomainEventHandler : INotificationHandler<OrderPlacedDomainEvent>
{
    public async Task Handle(OrderPlacedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}