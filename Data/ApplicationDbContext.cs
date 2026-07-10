using Microsoft.EntityFrameworkCore;
using PedidosBackend.Models;

namespace PedidosBackend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ;
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    
}