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
            //!!
            //Onconfiguring metod kullanmama sebebimiz; bu context'i kişisel olarak kulanmayacağız
            // ve her istekte bulunanı server'a yönlendireceğiz.
        }
    }
}
