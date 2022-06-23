
using Delivery.Application.CompleteDelivery;
using Delivery.Application.CreateDeliveryAsync;
using Delivery.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Delivery.Application;

public static class ConfigureServices
{
    public static void AddDeliveryApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<CreateDeliveryCommandHandler>();
        serviceCollection.AddTransient<DeliveryCreatedDomainEventHandler>();
        serviceCollection.AddTransient<CompleteDeliveryCommandHandler>();
        serviceCollection.AddTransient<DeliveryCompletedDomainEventHandler>();
        serviceCollection.AddDeliveryInfrastructure();
    }
}