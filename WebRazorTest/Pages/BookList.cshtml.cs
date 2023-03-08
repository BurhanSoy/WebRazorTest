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
            IEnumerable<Book> booktmp = BookDb.GetBooks(); //Ctor class olu�turuldu�unda �al���yor.// Class ise routing i�lemi s�ras�nda istek geldi�inde olu�uyor.
            
            Books = booktmp.Where(x => x .Title.Contains("�yi")).ToList();

            //Bu filtreleme OnGet metodu i�inde yaz�labilir.
            //OnGet metodunda yaz�l�rsa OnPost metodu bu iste�i kar��lamaz
            //Ctor i�inde olursa her metod i�in bu filtreleme �al���r.
        }                              
        public void OnGet() //Data Klas�r� i�indeki istekleri bu metod i�inde de yapabiliriz ancak as�l yeri BookDb
        {

        }
    }
}
