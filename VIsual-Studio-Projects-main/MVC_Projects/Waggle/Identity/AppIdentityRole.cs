using Microsoft.AspNetCore.Identity;

namespace Waggle.Identity
{
    public class AppIdentityRole : IdentityRole
    {
        public string Decsription { get; set; }
    }
}
