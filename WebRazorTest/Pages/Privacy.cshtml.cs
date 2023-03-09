using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebRazorTest.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        //public IActionResult OnGet() //Interface kullanımının amacı yeni bir teknoloji geldiği zaman kod değişikliği olmadan eklenebilmesini sağlar.
        //{
        //    _logger.LogInformation("Privacy'den Geçti");
        //    return RedirectToPage("index");
        //}

        public ActionResult OnGet() //privacy'e tıklandığında anasayfaya(Index) yönlendirecek. Status 302
        {
            _logger.LogInformation("Privacy'den Geçti");
            return NotFound();
            //return RedirectToPage("index"); //RedirectToPage kalıtım ile üretilmiş
            //Burada Privacy isteğine cevap veriyoruz.
        }

        // !!! RedirectToPage class'ı IActionResult'ı gerçekler ve ActionResult classından türetilir.
    }
}