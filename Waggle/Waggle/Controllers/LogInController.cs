using Microsoft.AspNetCore.Mvc;

namespace Waggle.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
