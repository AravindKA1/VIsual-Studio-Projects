using Microsoft.AspNetCore.Mvc;

namespace MvcAssessment.Controllers
{
    public class IdentityController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
