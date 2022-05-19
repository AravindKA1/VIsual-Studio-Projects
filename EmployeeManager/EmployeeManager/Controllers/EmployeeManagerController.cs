using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private AppDBContext db = null;
        public EmployeeManagerController(AppDBContext db)
        {
            this.db = db;
        }

        public  IActionResult List()
        { List<Employee> model= (from e in db.Employees
                                 orderby e.EmployeeId
                                 select e).ToList();
            return View(model);
        }
        
    }
}
