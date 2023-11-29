using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TMA.ECommerce.Api.Products.Db;
using TMA.ECommerce.Api.Products.Interfaces;

namespace TMA.ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductsDbContext dbContext;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.Add(new Product() { Id = 1, Name = "Keyboard", Price = 20, Inventory = 800 });
                dbContext.Products.Add(new Product() { Id = 2, Name = "Mouse", Price = 5, Inventory = 1100 });
                dbContext.Products.Add(new Product() { Id = 3, Name = "Monitor", Price = 150, Inventory = 100 });
                dbContext.Products.Add(new Product() { Id = 4, Name = "CPU", Price = 200, Inventory = 200 });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await dbContext.Products.ToListAsync();
                if (products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                logger?.LogInformation($"Querying products with id: {id}");
                var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    logger?.LogInformation("Product found");
                    var result = mapper.Map<Models.Product>(product);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
