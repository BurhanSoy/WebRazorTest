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
        //�stek gelip class olu�tu�unda bir DbContext isteniyor
        //IndexModel CustomerDbContext'e ba�l� ama gev�ek ba�l� (coupling - has a)

        //!!Has-a ili�kisi = Dependcy Injection
        //!!Burada yap�lan i�, ctor'da isterim private'ta saklar�m mant���
        //!!�steklere yan�t veren s�n�flar�n ctor'unda ba�l� olduklar� service'�n veya kayna��n verilmesi DI'd�r.

        public IndexModel(CustomerDbContext db)
        {
            _db = db;

        }

        public void OnGet()
        {
            Customers = _db.Customer.OrderBy(c => c.Id).ToList();
            // OrderBy'� delete i�lemi yapt�ktan sonra s�ralamada kayma olmas�n� engellemek i�in yapt�k.
        }
    }
}
