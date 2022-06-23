using Delivery.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Delivery.Api;

public static class ConfigureServices
{
    public static void AddDeliveryApi(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDeliveryApplication();
    }
}