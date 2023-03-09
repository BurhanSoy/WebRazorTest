using Microsoft.EntityFrameworkCore;
using WebRazorTest.Model;

namespace WebRazorTest.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }
    }
}
