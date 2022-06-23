using MediatR;
using Order.Domain.Order;
using Shared.Kernel.Abstractions;

namespace Order.Application.PlaceOrder;

public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Guid>
{
    private readonly IDomainEventPublisher _domainEventPublisher;
    private readonly IOrderRepository _orderRepository;

    public PlaceOrderCommandHandler(IDomainEventPublisher domainEventPublisher, IOrderRepository orderRepository)
    {
        _domainEventPublisher = domainEventPublisher;
        _orderRepository = orderRepository;
    }
    
    public async Task<Guid> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var orderAggregate = OrderAggregateRoot.Place(request.CustomerId, request.Products);
        await _orderRepository.Persist(orderAggregate);
        await orderAggregate.Commit(_domainEventPublisher);

        return orderAggregate.Id;
    }
}