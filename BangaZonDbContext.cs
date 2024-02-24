using Microsoft.EntityFrameworkCore;
using BangaZon_ND.Models;
using System.Runtime.CompilerServices;

public class BangaZonDbContext : DbContext
{

    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }
    public DbSet<User> Users { get; set; }
    public BangaZonDbContext(DbContextOptions<BangaZonDbContext> context) : base(context)
    {

    }
}