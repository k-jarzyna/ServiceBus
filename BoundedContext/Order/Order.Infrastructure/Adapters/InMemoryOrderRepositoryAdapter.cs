using Order.Domain.Order;

namespace Order.Infrastructure.Adapters;

public class InMemoryOrderRepositoryAdapter : IOrderRepository
{
    private List<OrderAggregateRoot> Orders = new List<OrderAggregateRoot>();
    public async Task<OrderAggregateRoot> Persist(OrderAggregateRoot orderAggregateRoot)
    {
        Orders.Add(orderAggregateRoot);

        return orderAggregateRoot;
    }

    public async Task<OrderAggregateRoot?> FindById(Guid id)
    {
        return Orders.FirstOrDefault(o => o.Id == id);
    }
}