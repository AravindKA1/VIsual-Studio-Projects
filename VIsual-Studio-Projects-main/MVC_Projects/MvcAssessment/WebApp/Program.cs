using Microsoft.EntityFrameworkCore;
using WebApp.Model;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerDbContext>(option => option.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDb")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*var scope = app.ApplicationServices.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
SeedData(context);*/

static void SeedData(CustomerDbContext context)
{
    Customer cus1 = new Customer
    {
        Id = 1,
        FirstName = "Aravind",
        LastName = "KA",
        Address = "Mallamgunta Road",
        Phone = 9182288966,
        Email = "aravind.kagh@gmail.com"
    };
    Customer cus2 = new Customer
    {
        Id = 1,
        FirstName = "Balu",
        LastName = "KA",
        Address = "Mallamgunta Road",
        Phone = 9652106382,
        Email = "balu.ka@gmail.com"
    };
    context.Customers.Add(cus1);
    context.Customers.Add(cus2);
    context.SaveChanges();
}