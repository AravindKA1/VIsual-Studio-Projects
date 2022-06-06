using Microsoft.AspNetCore.Mvc;

namespace Waggle.Controllers
{
    public class ReportsPageController : Controller
    {
        public IActionResult ReportsPage()
        {
            return View();
        }
    }
}
