using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TMA.ECommerce.Api.Products.Db
{
    public class ProductsDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
