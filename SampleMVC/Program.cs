using NutriaryWebApp.BLL.BLL;
using NutriaryWebApp.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IConsumedFoodsBLL, ConsumedFoodsBLL>();


var app = builder.Build();
app.UseStaticFiles();

// menambahkan mekanisme routing
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categories}/{action=Index}/{id?}"
);

app.Run();
