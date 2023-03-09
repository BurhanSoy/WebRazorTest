using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorTest.Data;

namespace WebRazorTest.Pages
{
    //[BindProperties] //Class i�indeki b�t�n prop'lar� bind eder.
    public class AddModel : PageModel
    {
        [BindProperty] 
        //�n taraftaki bir �eyle Bind etmek(ba�lamak)
        //Post i�lemi s�ras�nda add.cshtml dosyas�ndaki input name prop'nun e�le�mesi i�in bind edilmesi gerekiyor.
        //private prop'lar�n bind edilmesi s�z konusu de�il.
        public string Title { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public AddModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            _logger.LogInformation("Get iste�i");
        }

        public ActionResult OnPost() //Action Result in Razor Page
        {
            _logger.LogInformation("POST iste�i");

            return RedirectToPage("Index");
        }

        //public void OnPost() 
        //{
        //    //var form = Request.Form.ToList(); //Request ara�t�r.

        //    //_logger.LogInformation("Post iste�i");
        //}
    }
}
