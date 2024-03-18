using NutriaryWebApp.BLL.BLL;
using NutriaryWebApp.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddScoped<IConsumedFoodsBLL, ConsumedFoodsBLL>();
builder.Services.AddScoped<IAuthenticationBLL, AuthenticationBLL>();
builder.Services.AddScoped<ICreateUserBLL, CreateUserBLL>();
builder.Services.AddScoped<IUserProfileBLL, UserProfileBLL>();


var app = builder.Build();
app.UseStaticFiles();

// menambahkan mekanisme routing
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Login}/{id?}"
);

app.Run();
