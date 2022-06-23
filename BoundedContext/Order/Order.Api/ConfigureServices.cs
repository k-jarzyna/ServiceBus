using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Order.Application;

namespace Order.Api;

public static class ConfigureServices
{
    public static void AddOrderApi(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ConfigureServices).Assembly);
        serviceCollection.AddOrderApplication();
    }
}