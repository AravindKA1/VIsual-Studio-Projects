using Microsoft.EntityFrameworkCore;
using WaggleAPI.Models;

namespace WaggleAPI.Models
{
    public class AppDbContext : DbContext
    {
        //injects DbContext instances when required
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        //Allow us to access Persons as we mapped our model to db to perform CRUD
        public DbSet<Person> Persons { get; set; }
    }
}
