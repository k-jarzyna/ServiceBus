using Delivery.Domain.Delivery;
using Delivery.Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure;

namespace Delivery.Infrastructure;

public static class ConfigureServices
{
    public static void AddDeliveryInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextFactory<DeliveryDbContext>();
        // serviceCollection.AddDbContext<DeliveryDbContext>();
        serviceCollection.AddScoped<IDeliveryRepository, InMemoryDeliveryRepositoryAdapter>();
        serviceCollection.AddSharedInfrastructure();
    }
}