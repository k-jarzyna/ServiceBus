using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.CompleteOrder;
using Order.Application.OrderSagaWorkflow;
using Order.Application.PlaceOrderAsync;
using Order.Infrastructure;

namespace Order.Application;

public static class ConfigureServices
{
    public static void AddOrderApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ConfigureServices).Assembly);
        serviceCollection.AddTransient<PlaceOrderAsyncCommandHandler>();
        serviceCollection.AddTransient<OrderPlacedDomainEventListener>();
        serviceCollection.AddTransient<OrderCompletedDomainEventHandler>();
        serviceCollection.AddTransient<PlaceOrderSaga>();
        serviceCollection.AddOrderInfrastructure();
    }
}