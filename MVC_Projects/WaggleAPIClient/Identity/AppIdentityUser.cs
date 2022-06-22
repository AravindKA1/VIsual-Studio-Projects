using Microsoft.AspNetCore.Identity;

namespace WaggleAPIClient.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
