using Microsoft.EntityFrameworkCore;
using PedidosBackend.Models;

namespace PedidosBackend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Order>().Property(o => o.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderItems>().Property(oi => oi.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<OrderItems>()
            .HasOne(oi => oi.Product).WithMany()
            .HasForeignKey(oi => oi.ProductId);

        modelBuilder.Entity<OrderItems>()
            .HasOne(oi => oi.Order).WithMany(o =>  o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    
}