using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TMA.ECommerce.Api.Customers.Db
{
    public class CustomersDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomersDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
