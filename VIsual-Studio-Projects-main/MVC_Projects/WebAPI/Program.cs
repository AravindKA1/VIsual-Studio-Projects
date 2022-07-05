using Microsoft.EntityFrameworkCore;
using WaggleAPI.Models;
using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Added a service for our connection string used with the sqlserver
var connectionString = builder.Configuration.GetConnectionString("AppDB");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPersonRepository, PersonSqlRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());  

app.Run();