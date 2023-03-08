using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebRazorTest.Data;

namespace WebRazorTest.Pages
{
    public class BookDetailsModel : PageModel
    {
        public Book? Book { get; private set; }

        public void OnGet(int id)
        {
            Book = BookDb.GetBookById(id);
        }
    }
}
