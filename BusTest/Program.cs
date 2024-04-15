using BusTest.Models;
using BusTest.Repositories.Abstractions;
using BusTest.Repositories.Implimentations;
using BusTest.Services.Abstractions;
using BusTest.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => 
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUrlRepository, UrlRepository>();

builder.Services.AddScoped<IUrlService, UrlService>();

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

app.MapControllerRoute(
    name: "Redirect", 
    pattern: "{token}",
    defaults: new { controller = "Home", action = "Redirect"});

app.Run();