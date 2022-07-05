using Microsoft.AspNetCore.Identity;

namespace MyClient.Identity
{
    public class AppIdentityRole : IdentityRole
    {
        public string Decsription { get; set; }
    }
}
