using Microsoft.AspNetCore.Mvc;

namespace WaggleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
