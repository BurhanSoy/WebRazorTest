using Microsoft.EntityFrameworkCore;
using WebRazorTest.Data;

var builder = WebApplication.CreateBuilder(args); //WebApplicationBuilder

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseInMemoryDatabase("name")); //Bu tipte(CustomerDbContext) DbContext ekleyen metod
                                         //override edilen OnConfiguring metodunu bu þekilde server'a yaptýrýyoruz.(EFCore ile EF farký)
                                        //

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