using Microsoft.EntityFrameworkCore;

namespace WebApp.Model
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

    }
}
