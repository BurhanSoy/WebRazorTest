using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorTest.Data;
using WebRazorTest.Model;

namespace WebRazorTest.Pages.Customers
{
    public class CreateModel : PageModel
    {
        public Customer Customer { get; set; }
        private readonly CustomerDbContext _db;

        public CreateModel(CustomerDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
    }
}
