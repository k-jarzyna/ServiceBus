using Microsoft.Extensions.DependencyInjection;
using Order.Domain.Order;
using Order.Infrastructure.Adapters;
using Shared.Infrastructure;

namespace Order.Infrastructure;

public static class ConfigureServices
{
    public static void AddOrderInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSharedInfrastructure();
        serviceCollection.AddSingleton<IOrderRepository, InMemoryOrderRepositoryAdapter>();
    }
}