using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorTest.Data;
using WebRazorTest.Model;

namespace WebRazorTest.Pages.Customers
{
    public class CreateModel : PageModel
    {
        [BindProperty] //�ki y�nl� ba�lama
        public Customer Customer { get; set; }
        private readonly CustomerDbContext _db;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(CustomerDbContext db, ILogger<CreateModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void OnGet() 
        {
            //Get olunca create sayfas�na gelecek, void ile ilgili sayfay� d�nd�recek
            //Bunun di�er kar��l��� ---> public ActionResult OnGet(x => x.return Page())
            //OnGet'te Customer null
            //Kar�� taraftan post edildi�inde yukar�daki Customer doluyor (bir nevi yeri de�i�meyen sepet)
        }

        public ActionResult OnPost() //Farkl� sayfaya ge�i� i�in void de�il ActionResult kullan�yoruz
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("GE�ERS�Z!!!! ");
                return Page();
            }

            if (Customer != null)
            {
                _db.Customer.Add(Customer);
                _db.SaveChanges();
                return RedirectToPage("index");
            }

            return Page();
        }
    }
}
