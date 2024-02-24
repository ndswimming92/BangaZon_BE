using Microsoft.EntityFrameworkCore;
using BangaZon_ND.Models;
using System.Runtime.CompilerServices;

public class BangaZonDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
        new Category {Id = 1, Name = "Tent", ItemCount = 1},
        new Category {Id = 2, Name = "RV", ItemCount = 2},
        new Category {Id = 3, Name = "Primitive", ItemCount = 10},
        new Category {Id = 4, Name = "Hammock", ItemCount = 12}
        });
    }

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