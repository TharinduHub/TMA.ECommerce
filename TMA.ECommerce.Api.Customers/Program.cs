using Microsoft.EntityFrameworkCore;
using TMA.ECommerce.Api.Customers.Db;
using TMA.ECommerce.Api.Customers.Interfaces;
using TMA.ECommerce.Api.Customers.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICustomersProvider, CustomersProvider>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<CustomersDbContext>(options =>
{
    options.UseInMemoryDatabase("Customers");
});

var app = builder.Build();

app.MapControllers();


app.Run();