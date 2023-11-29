using Microsoft.EntityFrameworkCore;
using TMA.ECommerce.Api.Orders.Db;
using TMA.ECommerce.Api.Orders.Interfaces;
using TMA.ECommerce.Api.Orders.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IOrdersProvider, OrdersProvider>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseInMemoryDatabase("Orders");
});

var app = builder.Build();

app.MapControllers();


app.Run();