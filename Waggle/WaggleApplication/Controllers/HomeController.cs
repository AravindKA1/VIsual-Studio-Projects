using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WaggleApplication.Controllers
{
	public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult HomePage()
        {
            return View();
        }

       
        public IActionResult LogIn()
        {
            return View();
        }
    }
}