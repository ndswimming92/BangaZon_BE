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


// Endpoint to See all sellers Products
app.MapGet("/api/seeAllProducts", async (BangaZonDbContext db) =>
{
    
        var products = await db.Products
            .Where(p => p.UserIsSeller == true)
            .ToListAsync();

        return Results.Ok(products);
    
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
        return Results.NotFound("No Orders found for this customer.");
    }

    return Results.Ok(allOrdersForOneUser);
});

// Customer can delete a product from an order.


app.Run();