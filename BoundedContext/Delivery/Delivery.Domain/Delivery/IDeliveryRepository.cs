namespace Delivery.Domain.Delivery;

public interface IDeliveryRepository
{
    public Task<DeliveryAggregateRoot> Persist(DeliveryAggregateRoot deliveryAggregateRoot);
    
    public Task<DeliveryAggregateRoot> Update(DeliveryAggregateRoot deliveryAggregateRoot);

    public Task<DeliveryAggregateRoot?> FindById(Guid id);
}