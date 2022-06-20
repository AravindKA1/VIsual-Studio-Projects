using Microsoft.EntityFrameworkCore;
using Waggle.Identity;
using Waggle.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Added a service for our connection string used with the sqlserver
var connectionString = builder.Configuration.GetConnectionString("AppDB");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/SignIn";
    options.AccessDeniedPath = "/Identity/AccessDenied";
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}*/
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=ListOfPersons}/{id?}");

app.Run();
