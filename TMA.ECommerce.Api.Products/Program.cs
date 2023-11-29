using Microsoft.EntityFrameworkCore;
using TMA.ECommerce.Api.Products.Db;
using TMA.ECommerce.Api.Products.Interfaces;
using TMA.ECommerce.Api.Products.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IProductsProvider, ProductsProvider>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ProductsDbContext>(options =>
{
    options.UseInMemoryDatabase("Products");
});

var app = builder.Build();

app.MapControllers();


app.Run();
