using Microsoft.AspNetCore.Mvc;

namespace Waggle.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
