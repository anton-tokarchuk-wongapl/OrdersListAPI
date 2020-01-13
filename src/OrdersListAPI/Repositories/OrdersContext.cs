using Microsoft.EntityFrameworkCore;
using OrdersListAPI.Entities;

namespace OrdersListAPI.Repositories
{
    public class OrdersContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<StatusEntity> Statuses { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product can have many orders and Order have just one product. One-to-Many Relationship.
            modelBuilder.Entity<ProductEntity>()
                        .HasMany(product => product.Orders)
                        .WithOne(order => order.Product)
                        .HasForeignKey(key => key.ProductId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Status can have many orders and Order have just one status. One-to-Many Relationship.
            modelBuilder.Entity<StatusEntity>()
                        .HasMany(status => status.Orders)
                        .WithOne(order => order.Status)
                        .HasForeignKey(key => key.StatusId);
        }
    }
}
