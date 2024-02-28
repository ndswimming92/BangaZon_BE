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

// Endpoint to search for products
app.MapGet("/api/searchProducts", async (BangaZonDbContext db, string keyword) =>
{
    
    if (string.IsNullOrEmpty(keyword))
    {
        return Results.BadRequest("Keyword cannot be empty.");
    }

    var products = await db.Products
        .Where(p => p.Title.Contains(keyword) || p.Description.Contains(keyword))
        .ToListAsync();

    return Results.Ok(products);
});

//Get All Users
app.MapGet("/api/users", (BangaZonDbContext db) =>
{
    return db.Users.ToList();
});

// Customer can delete a product from an order.


app.Run();