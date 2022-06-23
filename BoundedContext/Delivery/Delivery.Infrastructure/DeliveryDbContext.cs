using Delivery.Domain.Delivery;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Infrastructure;

public class DeliveryDbContext : DbContext
{
    public DbSet<DeliveryAggregateRoot> Deliveries { get; set; }

    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=ServiceBus;Username=postgres;Password=postgres");
    }
}