using Microsoft.EntityFrameworkCore;
using WebRazorTest.Data;

var builder = WebApplication.CreateBuilder(args); //WebApplicationBuilder

// Add services to the container.
builder.Services.AddRazorPages();

/*UseInMemoryDatabase("name") metodunun parametresi asl�nda connection string*/
builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.
    GetConnectionString("myconn")));      //Bu tipte(CustomerDbContext) DbContext ekleyen metod
                                         //override edilen OnConfiguring metodunu bu �ekilde server'a yapt�r�yoruz.(EFCore ile EF fark�)
                                        //Service'in nas�l ba�lat�laca��n� buradan belirliyoruz.
                                       //data ile ilgili bilgileri CustDbContext kar��l�yor
                                      //!!Buradaki i�lem de asl�nda dependency injection!!
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();