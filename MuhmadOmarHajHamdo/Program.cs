using Microsoft.EntityFrameworkCore;
using MuhmadOmarHajHamdo.Context;

var builder = WebApplication.CreateBuilder(args);
// Server=localhost;Database=MuhmadOmar;Trusted_Connection=True;
// Add services to the container.
builder.Services.AddControllersWithViews();

//  DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MuhmadOmarHajHamdoContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();