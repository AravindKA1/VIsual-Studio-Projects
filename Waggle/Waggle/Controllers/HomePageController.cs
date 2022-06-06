using Microsoft.AspNetCore.Mvc;

namespace Waggle.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
