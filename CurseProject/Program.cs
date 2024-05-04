using CurseProject.Context;
using CurseProject.Models;
using CurseProject.Repository;
using CurseProject.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>{
        options.LoginPath = "/Account/Registered";
        options.AccessDeniedPath = "";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<PostgresDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITriangleRepository,TriangleRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IAuthService,AuthService>();

builder.Services.AddSession();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();