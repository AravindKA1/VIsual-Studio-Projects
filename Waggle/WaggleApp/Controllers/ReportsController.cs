using Microsoft.AspNetCore.Mvc;

namespace WaggleApp.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult ReportsPage()
        {
            return View();
        }
    }
}
