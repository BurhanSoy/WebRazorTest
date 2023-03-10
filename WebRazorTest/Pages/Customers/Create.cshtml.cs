using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorTest.Data;
using WebRazorTest.Model;

namespace WebRazorTest.Pages.Customers
{
    public class CreateModel : PageModel
    {
        [BindProperty] //Ýki yönlü baðlama
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
            //Get olunca create sayfasýna gelecek, void ile ilgili sayfayý döndürecek
            //Bunun diðer karþýlýðý ---> public ActionResult OnGet(x => x.return Page())
            //OnGet'te Customer null
            //Karþý taraftan post edildiðinde yukarýdaki Customer doluyor (bir nevi yeri deðiþmeyen sepet)
        }

        public ActionResult OnPost() //Farklý sayfaya geçiþ için void deðil ActionResult kullanýyoruz
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("GEÇERSÝZ!!!! ");
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
