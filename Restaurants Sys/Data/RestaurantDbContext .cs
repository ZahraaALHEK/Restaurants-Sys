using Microsoft.EntityFrameworkCore;
using Restaurants_Sys.Models;

namespace Restaurants_Sys.Data;
public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options)
    {
    }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Extra> Extras { get; set; }
    public DbSet<MenuItemExtra> MenuItemExtras { get; set; }
    public DbSet<OrderItemExtra> OrderItemExtras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure composite primary keys for junction tables
        modelBuilder.Entity<MenuItemExtra>()
            .HasKey(me => new { me.MenuItemId, me.ExtraId });

        modelBuilder.Entity<OrderItemExtra>()
            .HasKey(oe => new { oe.OrderItemId, oe.ExtraId });

        base.OnModelCreating(modelBuilder);
    }
}