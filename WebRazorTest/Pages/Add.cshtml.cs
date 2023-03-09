using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazorTest.Data;

namespace WebRazorTest.Pages
{
    //[BindProperties] //Class içindeki bütün prop'larý bind eder.
    public class AddModel : PageModel
    {
        [BindProperty] 
        //Ön taraftaki bir þeyle Bind etmek(baðlamak)
        //Post iþlemi sýrasýnda add.cshtml dosyasýndaki input name prop'nun eþleþmesi için bind edilmesi gerekiyor.
        //private prop'larýn bind edilmesi söz konusu deðil.
        public string Title { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public AddModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            _logger.LogInformation("Get isteði");
        }

        public ActionResult OnPost() //Action Result in Razor Page
        {
            _logger.LogInformation("POST isteði");

            return RedirectToPage("Index");
        }

        //public void OnPost() 
        //{
        //    //var form = Request.Form.ToList(); //Request araþtýr.

        //    //_logger.LogInformation("Post isteði");
        //}
    }
}
