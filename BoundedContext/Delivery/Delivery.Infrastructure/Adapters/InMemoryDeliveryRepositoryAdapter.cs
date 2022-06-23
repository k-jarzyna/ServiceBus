using Delivery.Domain.Delivery;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infrastructure.Adapters;

public class InMemoryDeliveryRepositoryAdapter : IDeliveryRepository
{
    private readonly DeliveryDbContext _context;

    public InMemoryDeliveryRepositoryAdapter(DeliveryDbContext context)
    {
        _context = context;
    }

    public async Task<DeliveryAggregateRoot> Persist(DeliveryAggregateRoot deliveryAggregateRoot)
    {
        await _context.Deliveries.AddAsync(deliveryAggregateRoot);
        await _context.SaveChangesAsync();

        return deliveryAggregateRoot;
    }

    public async Task<DeliveryAggregateRoot?> FindById(Guid id)
    {
        return await _context.Deliveries.FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<DeliveryAggregateRoot> Update(DeliveryAggregateRoot deliveryAggregateRoot)
    {
        _context.Deliveries.Update(deliveryAggregateRoot);
        await _context.SaveChangesAsync();

        return deliveryAggregateRoot;
    }
}