using Microsoft.EntityFrameworkCore;
using MediatR;
using CqrsMediatR_Demo.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core InMemory
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("DemoDb"));

// MediatR - scan this assembly
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new() { Name = "Apple", Description = "Red apple", Price = 0.5m },
            new() { Name = "Banana", Description = "Yellow banana", Price = 0.3m }
        );
    }
    if (!db.Customers.Any())
    {
        db.Customers.AddRange(
            new() { Name = "Alice", Email = "alice@example.com" },
            new() { Name = "Bob", Email = "bob@example.com" }
        );
    }
    db.SaveChanges();
}

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
