using System.ComponentModel.DataAnnotations;

namespace WebRazorTest.Model
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string? Name { get; set; }
        //Ön taraftan sadece name geliyor.
        //Id'yi EF hallediyor.
    }
}
