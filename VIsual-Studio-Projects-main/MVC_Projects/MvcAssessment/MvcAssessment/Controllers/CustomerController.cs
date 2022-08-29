using Microsoft.AspNetCore.Mvc;

namespace MvcAssessment.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult ListOfCustomers()
        {
            return View();
        }
    }
}
