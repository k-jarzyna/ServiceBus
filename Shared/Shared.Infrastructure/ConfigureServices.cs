using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Adapters;
using Shared.Kernel.Abstractions;

namespace Shared.Infrastructure;

public static class ConfigureServices
{
    public static void AddSharedInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IMediator, Mediator>();
        serviceCollection.AddScoped<IDomainEventPublisher, DomainEventPublisherAdapter>();
    }
}