using Microsoft.AspNetCore.Mvc;

namespace WaggleApp.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
