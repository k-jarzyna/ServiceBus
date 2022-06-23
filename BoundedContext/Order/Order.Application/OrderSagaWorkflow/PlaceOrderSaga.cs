using Delivery.Contract.Command;
using Delivery.Contract.IntegrationEvent;
using NServiceBus;
using NServiceBus.Persistence.Sql;
using Order.Application.CompleteOrder;
using Order.Contract.IntegrationEvent;

namespace Order.Application.OrderSagaWorkflow;

[SqlSaga(
    tableSuffix: "PlaceOrderSaga"
)]
public class PlaceOrderSaga : Saga<PlaceOrderSagaData>,
    IAmStartedByMessages<OrderPlacedIntegrationEvent>,
    IHandleMessages<DeliveryCreatedIntegrationEvent>,
    IHandleMessages<DeliveryCompletedIntegrationEvent>,
    IHandleMessages<OrderCompletedIntegrationEvent>
{
    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PlaceOrderSagaData> mapper)
    {
        mapper.MapSaga(data => data.OrderId)
            .ToMessage<OrderPlacedIntegrationEvent>(m => m.OrderId)
            .ToMessage<DeliveryCreatedIntegrationEvent>(m => m.OrderId)
            .ToMessage<DeliveryCompletedIntegrationEvent>(m => m.OrderId)
            .ToMessage<OrderCompletedIntegrationEvent>(m => m.OrderId);
    }

    public async Task Handle(OrderPlacedIntegrationEvent message, IMessageHandlerContext context)
    {
        Console.WriteLine($"saga step 1 - OrderPlaced => CreateDelivery {message.OrderId.ToString()}");
        await context.Send(new CreateDeliveryCommand()
        {
            OrderId = message.OrderId
        });

        Data.IsOrderPlaced = true;
    }

    public async Task Handle(DeliveryCreatedIntegrationEvent message, IMessageHandlerContext context)
    {
        Console.WriteLine($"saga step 2 - DeliveryCreated => MarkOrderInTransit {message.OrderId.ToString()}");
        Data.IsDeliveryScheduled = true;
    }

    public async Task Handle(DeliveryCompletedIntegrationEvent message, IMessageHandlerContext context)
    {
        Console.WriteLine($"saga step 3 - DeliveryCompleted => CompleteOrder {message.OrderId.ToString()}");
        await context.Send(new CompleteOrderCommand()
        {
            OrderId = message.OrderId
        });
        
        Data.IsDeliveryCompleted = true;
    }

    public async Task Handle(OrderCompletedIntegrationEvent message, IMessageHandlerContext context)
    {
        Console.WriteLine($"saga completed - OrderCompleted id = {message.OrderId.ToString()}");
        Data.IsOrderCompleted = true;
        
        MarkAsComplete();
    }
}