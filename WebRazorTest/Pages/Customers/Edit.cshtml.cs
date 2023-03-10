using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebRazorTest.Data;
using WebRazorTest.Model;

namespace WebRazorTest.Pages.Customers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }

        private readonly CustomerDbContext _db;
        private readonly ILogger<EditModel> _logger;

        public EditModel(CustomerDbContext db, ILogger<EditModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        public ActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _db.Customer.FirstOrDefault(m => m.Id == id); //Getireceði deðer Customer tipinde olacaðý için defaultu null

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Customer != null)
            {
                _db.Attach(Customer).State = EntityState.Modified; //EntityState.Modified ---> Entity context'te ve veritabanýnda farklý deðere sahipse SaveChanges ile kayýt bekler (update)
                //Ayný andalýk(concurrency)/ Baþka biri bu veriyi alýrsa bloke etmeye çalýþýyor.

                try
                {
                    _db.SaveChanges(); //Hata yoksa kaydediyor
                }
                catch (DbUpdateConcurrencyException) //Ayný andalýk hatasý
                {
                    if (!CustomerExists(Customer.Id)) 
                        //Bu hata olduysa, Id'nin olmama durumunu sorguluyor.(Hata olmamasý mý diye) Silinmiþ olabilir mi?
                    {
                        return NotFound(); //true ise
                    }
                    else //
                    {
                        throw; //False ise hata fýrlat
                    }
                }
            }

            return RedirectToPage("Index");
        }

        private bool CustomerExists(int id)
        {
            return _db.Customer.Any(e => e.Id == id);
        }
    }
}
