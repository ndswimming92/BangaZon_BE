using Microsoft.EntityFrameworkCore;
using BangaZon_ND.Models;
using System.Runtime.CompilerServices;
using System;

public class BangaZonDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with Category types
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
        new Category {Id = 1, Name = "Tent", ItemCount = 1},
        new Category {Id = 2, Name = "RV", ItemCount = 2},
        new Category {Id = 3, Name = "Primitive", ItemCount = 10},
        new Category {Id = 4, Name = "Hammock", ItemCount = 12}
        });


        // seed data with Order types
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
        new Order {Id = 1, UserId = 1, PaymentType = 1, OrderDate = DateTime.Now, OrderStatus = true, ProductsId = 1},
        new Order {Id = 2, UserId = 2, PaymentType = 2, OrderDate = DateTime.Now, OrderStatus = true, ProductsId = 2},
        new Order {Id = 3, UserId = 3, PaymentType = 1, OrderDate = DateTime.Now, OrderStatus = false, ProductsId = 3}
        });

        // seed data with PaymentType types
        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
        new PaymentType {Id = 1, UserId = 1, Type = "Type1"},
        new PaymentType {Id = 2, UserId = 2, Type = "Type2"},
        new PaymentType {Id = 3, UserId = 3, Type = "Type3"}
        });

        // seed data with Product types
        modelBuilder.Entity<Product>().HasData(new Product[]
        {
        new Product {Id = 1, Title = "Product 1", Description = "Description 1", QuantityAvailable = 10, PricePerUnit = 100, CategoryId = 1, TimePosted = DateTime.Now, UserId = 1, UserIsSeller = true},
        new Product {Id = 2, Title = "Product 2", Description = "Description 2", QuantityAvailable = 20, PricePerUnit = 200, CategoryId = 2, TimePosted = DateTime.Now, UserId = 2, UserIsSeller = false},
        new Product {Id = 3, Title = "Product 3", Description = "Description 3", QuantityAvailable = 30, PricePerUnit = 300, CategoryId = 3, TimePosted = DateTime.Now, UserId = 3, UserIsSeller = true}
        });

        // seed data with ProductOrder types
        modelBuilder.Entity<ProductOrder>().HasData(new ProductOrder[]
        {
        new ProductOrder {Id = 1, OrderId = 1, ProductId = 1},
        new ProductOrder {Id = 2, OrderId = 2, ProductId = 2},
        new ProductOrder {Id = 3, OrderId = 3, ProductId = 3}
        });

        // seed data with User types
        modelBuilder.Entity<User>().HasData(new User[]
        {
        new User {Id = 1, Name = "Nicholas Davidson", Email = "user1@example.com", IsSeller = true},
        new User {Id = 2, Name = "James Collier", Email = "user2@example.com", IsSeller = false},
        new User {Id = 3, Name = "Willy Wonka", Email = "user3@example.com", IsSeller = false}
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