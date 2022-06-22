using Microsoft.AspNetCore.Identity;

namespace WaggleAPIClient.Identity
{
    public class AppIdentityRole : IdentityRole
    {
        public string Decsription { get; set; }
    }
}
