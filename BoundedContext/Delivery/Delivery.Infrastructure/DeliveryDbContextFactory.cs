using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Delivery.Infrastructure;

public class DeliveryDbContextFactory : IDesignTimeDbContextFactory<DeliveryDbContext>
{
    public DeliveryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DeliveryDbContext>();

        optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=ServiceBus;Username=postgres;Password=postgres");

        return new DeliveryDbContext(optionsBuilder.Options);
    }
}