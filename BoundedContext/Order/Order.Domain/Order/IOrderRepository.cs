namespace Order.Domain.Order;

public interface IOrderRepository
{
    public Task<OrderAggregateRoot> Persist(OrderAggregateRoot orderAggregateRoot);

    public Task<OrderAggregateRoot?> FindById(Guid id);
}