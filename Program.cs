using BangaZon_ND.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangaZonDbContext>(builder.Configuration["BangaZonDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Get all sellers Products
app.MapGet("/api/products/bySeller", (BangaZonDbContext db, int UserId) =>
{
    var productsBySeller = db.Products.Where(c => c.UserId == UserId).ToList();

    // If products do NOT match
    if (!productsBySeller.Any())
    {
        return Results.NotFound("No Products found for this seller.");
    }

    return Results.Ok(productsBySeller);
});

// Get Single product
app.MapGet("/api/products/{id}", (BangaZonDbContext db, int id) =>
{
    var productId = db.Products.FirstOrDefault(c => c.Id == id);

    if (productId == null)
    {
        return Results.NotFound("Product Not Found.");
    }

    return Results.Ok(productId);
});

//Get All Users
app.MapGet("/api/users", (BangaZonDbContext db) =>
{
    return db.Users.ToList();
});

//Get Single User
app.MapGet("/api/users/{id}", (BangaZonDbContext db, int id) =>
{
    var userId = db.Users.FirstOrDefault(c => c.Id == id);

    if (userId == null)
    {
        return Results.NotFound("User was not found.");
    }

    return Results.Ok(userId);
});

// Get All orders for one user
app.MapGet("/api/orders/forUser", (BangaZonDbContext db, int UserId) =>
{
    var allOrdersForOneUser = db.Orders.Where(c => c.UserId == UserId).ToList();

    if (!allOrdersForOneUser.Any())
    {
        return Results.NotFound("No Orders found for this user.");
    }

    return Results.Ok(allOrdersForOneUser);
});

// Get All Products
app.MapGet("/api/products", (BangaZonDbContext db) =>
{
    return db.Products.ToList();
});

// Get All Products for a single Category
app.MapGet("/api/products/byCategory", (BangaZonDbContext db, int categoryId) =>
{
    var productsByCategory = db.Products.Where(c => c.CategoryId == categoryId).ToList();

    if (!productsByCategory.Any())
    {
        return Results.NotFound("No Products found for this category.");
    }

    return Results.Ok(productsByCategory);
});

// Create a New User
app.MapPost("/api/createNewUser", (BangaZonDbContext db, User newUser) =>
{
    db.Users.Add(newUser);
    db.SaveChanges();
    return Results.Created($"/api/createNewUser/{newUser.Id}", newUser);
});

// Create a New Order
app.MapPost("/api/createNewOrder", (BangaZonDbContext db, Order newOrder) =>
{
    db.Orders.Add(newOrder);
    db.SaveChanges();
    return Results.Created($"/api/createNewOrder/{newOrder.Id}", newOrder);
});

// Create a New Product
app.MapPost("/api/createNewProduct", (BangaZonDbContext db, Product newProduct) =>
{
    db.Products.Add(newProduct);
    db.SaveChanges();
    return Results.Created($"/api/createNewProduct/{newProduct.Id}", newProduct);
});

// Add a Product to an Order
app.MapPost("/api/addProductToOrder", (BangaZonDbContext db, ProductOrder newProductOrder) =>
{
    db.ProductOrders.Add(newProductOrder);
    db.SaveChanges();
    return Results.Created($"/api/addProductToOrder/{newProductOrder.Id}", newProductOrder);
});

// Update a User
app.MapPut("/api/updateUser/{id}", (BangaZonDbContext db, int id, User user) =>
{
    User updatedUser = db.Users.SingleOrDefault(user => user.Id == id);

    if (updatedUser == null)
    {
        return Results.NotFound();
    }

    updatedUser.Name = user.Name;
    updatedUser.Email = user.Email;
    updatedUser.IsSeller = user.IsSeller;

    db.SaveChanges();
    return Results.NoContent();
});

// Update a Product
app.MapPut("/api/updateProduct/{id}", (BangaZonDbContext db, int id, Product product) =>
{
    Product updatedProduct = db.Products.SingleOrDefault(product => product.Id == id);
    if (updatedProduct == null)
    {
        return Results.NotFound();
    }

    updatedProduct.Title = product.Title;
    updatedProduct.Description = product.Description;
    updatedProduct.QuantityAvailable = product.QuantityAvailable;
    updatedProduct.PricePerUnit = product.PricePerUnit;
    updatedProduct.CategoryId = product.CategoryId;
    updatedProduct.TimePosted = product.TimePosted;
    updatedProduct.UserId = product.UserId;
    updatedProduct.UserIsSeller = product.UserIsSeller;


    db.SaveChanges();
    return Results.Created($"/api/updateProduct/{id}/{product.Id}", product);
});

// Update a Order

app.Run();