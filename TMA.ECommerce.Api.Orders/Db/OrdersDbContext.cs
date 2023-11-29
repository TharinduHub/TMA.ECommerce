using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TMA.ECommerce.Api.Orders.Db
{
    public class OrdersDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrdersDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
