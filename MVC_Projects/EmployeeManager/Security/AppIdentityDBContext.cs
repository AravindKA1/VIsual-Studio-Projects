using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Security
{
    public class AppIdentityDBContext : IdentityDbContext<AppIdentityUser,AppIdentityRole,string>
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options)
            :base(options)
        {

        }

    }
}
