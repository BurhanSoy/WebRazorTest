using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorTest.Data;
using WebRazorTest.Model;

namespace WebRazorTest.Pages.Customers
{
    //: PageModel MVC'de Controller olacak
    public class IndexModel : PageModel
    {
        public List<Customer> Customers { get; set; }

        private readonly CustomerDbContext _db; 
        //Ýstek gelip class oluþtuðunda bir DbContext isteniyor
        //IndexModel CustomerDbContext'e baðlý ama gevþek baðlý (coupling - has a)

        //!!Has-a iliþkisi = Dependcy Injection
        //!!Burada yapýlan iþ, ctor'da isterim private'ta saklarým mantýðý
        //!!Ýsteklere yanýt veren sýnýflarýn ctor'unda baðlý olduklarý service'ýn veya kaynaðýn verilmesi DI'dýr.

        public IndexModel(CustomerDbContext db)
        {
            _db = db;

        }

        public void OnGet()
        {
            Customers = _db.Customer.OrderBy(c => c.Id).ToList();
            // OrderBy'ý delete iþlemi yaptýktan sonra sýralamada kayma olmasýný engellemek için yaptýk.
        }
    }
}
