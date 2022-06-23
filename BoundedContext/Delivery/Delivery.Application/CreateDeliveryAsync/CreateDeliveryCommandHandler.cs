using Delivery.Contract.Command;
using Delivery.Domain.Delivery;
using NServiceBus;

namespace Delivery.Application.CreateDeliveryAsync;

public class CreateDeliveryCommandHandler : IHandleMessages<CreateDeliveryCommand>
{
    private readonly IDeliveryRepository _deliveryRepository;

    public CreateDeliveryCommandHandler(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }
    
    public async Task Handle(CreateDeliveryCommand message, IMessageHandlerContext context)
    {
        var deliveryAggregate = DeliveryAggregateRoot.Make(message.OrderId);
        
        Console.WriteLine($"CreateDelivery - Delivery id = {deliveryAggregate.Id.ToString()}");

        await _deliveryRepository.Persist(deliveryAggregate);

        await context.Publish(new DeliveryCreatedDomainEvent()
        {
            DeliveryId = deliveryAggregate.Id,
            OrderId = deliveryAggregate.OrderId
        });
    }
}