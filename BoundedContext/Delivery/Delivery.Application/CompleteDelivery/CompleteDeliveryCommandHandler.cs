using Delivery.Contract.Command;
using Delivery.Domain.Delivery;
using NServiceBus;

namespace Delivery.Application.CompleteDelivery;

public class CompleteDeliveryCommandHandler : IHandleMessages<CompleteDeliveryCommand>
{
    private readonly IDeliveryRepository _deliveryRepository;

    public CompleteDeliveryCommandHandler(IDeliveryRepository deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }
    
    public async Task Handle(CompleteDeliveryCommand message, IMessageHandlerContext context)
    {
        Console.WriteLine($"CompleteDelivery - delivery id = {message.DeliveryId}");

        var deliveryAggregate = await _deliveryRepository.FindById(message.DeliveryId);

        if (deliveryAggregate is null)
        {
            throw new Exception("Delivery not found");
        }
        
        deliveryAggregate.Complete();
        
        await _deliveryRepository.Update(deliveryAggregate);

        await context.Publish(new DeliveryCompletedDomainEvent()
        {
            DeliveryId = deliveryAggregate.Id,
            OrderId = deliveryAggregate.OrderId
        });
    }
}