using Delivery.Contract.Command;
using Npgsql;
using NpgsqlTypes;
using NServiceBus;
using Order.Application.CancelOrder;
using Order.Application.CompleteOrder;
using Order.Application.MarkOrderInTransit;
using Order.Message;
using ServiceBus;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(c => c.UseStartup<Startup>())
    .ConfigureServices((host, serviceCollection) =>
    {
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
        serviceCollection.AddServices();
    }).UseNServiceBus(context =>
    {
        var ServiceBusToken = "ServiceBus";
        var endpointConfiguration = new EndpointConfiguration(ServiceBusToken);
        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        transport.UseConventionalRoutingTopology();
        transport.ConnectionString("host=localhost");
        var connection = "Host=127.0.0.1;Database=ServiceBus;Username=postgres;Password=postgres";
        // var persistence = endpointConfiguration.UsePersistence<InMemoryPersistence>();
        var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
        // var subscriptions = persistence.SubscriptionSettings();
        // subscriptions.CacheFor(TimeSpan.FromMinutes(1));
        var dialect = persistence.SqlDialect<SqlDialect.PostgreSql>();
        dialect.JsonBParameterModifier(
            modifier: parameter =>
            {
                var npgsqlParameter = (NpgsqlParameter)parameter;
                npgsqlParameter.NpgsqlDbType = NpgsqlDbType.Jsonb;
            });
        persistence.ConnectionBuilder(
            connectionBuilder: () => { return new NpgsqlConnection(connection); });

        var routing = transport.Routing();

        routing.RouteToEndpoint(typeof(PlaceOrderRequest), ServiceBusToken);
        routing.RouteToEndpoint(typeof(CreateDeliveryCommand), ServiceBusToken);
        routing.RouteToEndpoint(typeof(CompleteOrderCommand), ServiceBusToken);
        routing.RouteToEndpoint(typeof(MarkOrderInTransitCommand), ServiceBusToken);
        routing.RouteToEndpoint(typeof(CancelOrderCommand), ServiceBusToken);
        routing.RouteToEndpoint(typeof(CompleteDeliveryCommand), ServiceBusToken);
        endpointConfiguration.EnableCallbacks();
        endpointConfiguration.MakeInstanceUniquelyAddressable(ServiceBusToken);
        endpointConfiguration.AutoSubscribe();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.EnableOutbox();

        return endpointConfiguration;
    }).Build();

host.Run();