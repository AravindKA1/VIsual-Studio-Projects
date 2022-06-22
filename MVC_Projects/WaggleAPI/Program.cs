using WaggleAPI.Models;
using Microsoft.EntityFrameworkCore;
using WaggleAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("AppDB");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPersonRepository, PersonSqlRepository>();





var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");  
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    });
