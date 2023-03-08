using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebRazorTest.Data;

namespace WebRazorTest.Pages
{
    public class BookListModel : PageModel
    {
        public int TestSayi { get; set; }
        public string? TestString { get; set; }

        public List<Book> Books { get; set; }

        public BookListModel()
        {
            IEnumerable<Book> booktmp = BookDb.GetBooks(); //Ctor class oluþturulduðunda çalýþýyor.// Class ise routing iþlemi sýrasýnda istek geldiðinde oluþuyor.
            
            Books = booktmp.Where(x => x .Title.Contains("Ýyi")).ToList();

            //Bu filtreleme OnGet metodu içinde yazýlabilir.
            //OnGet metodunda yazýlýrsa OnPost metodu bu isteði karþýlamaz
            //Ctor içinde olursa her metod için bu filtreleme çalýþýr.
        }                              
        public void OnGet() //Data Klasörü içindeki istekleri bu metod içinde de yapabiliriz ancak asýl yeri BookDb
        {

        }
    }
}
