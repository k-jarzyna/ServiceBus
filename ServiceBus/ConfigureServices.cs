using Delivery.Api;
using Order.Api;

namespace ServiceBus;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddOrderApi();
        serviceCollection.AddDeliveryApi();
    }
}