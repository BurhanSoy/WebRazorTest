using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebRazorTest.Data;

namespace WebRazorTest.Pages
{
    public class BookListModel : PageModel
    {
        public List<Book> Books { get; set; }

        public BookListModel()
        {
            //Ctor class oluþturulduðunda çalýþýyor.// Class ise routing iþlemi sýrasýnda istek geldiðinde oluþuyor.
            //IEnumerable<Book> booktmp = BookDb.GetBooks(); 
            
            //Books = booktmp.Where(x => x .Title.Contains("Ýyi")).ToList();

            //Bu filtreleme OnGet metodu içinde yazýlabilir.
            //OnGet metodunda yazýlýrsa OnPost metodu bu isteði karþýlamaz
            //Ctor içinde olursa her metod için bu filtreleme çalýþýr.
        }                 
        public void OnGet() //Data Klasörü içindeki istekleri bu metod içinde de yapabiliriz ancak asýl yeri BookDb
        {
            //Handler Metod (C# yani programlama tarafýndaki tarifi) 
            //HTTP Verbs ---> Get Post Put Delete
            
            Books = BookDb.GetBooks().ToList();
        }
    }
}
