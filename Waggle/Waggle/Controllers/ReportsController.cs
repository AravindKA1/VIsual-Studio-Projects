using Microsoft.AspNetCore.Mvc;

namespace Waggle.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult ReportsPage()
        {
            return View();
        }
    }
}
