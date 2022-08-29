using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Waggle.Models;

namespace Waggle.Controllers
{
    [Authorize(Roles = "WaggleUser")]
    public class HomeController : Controller
    {
        //dependency injection feature for asp.net core
        private AppDbContext db = null;
        //injecting AppDbContext to the constructor to have all the functionality of AppDbContext
        public HomeController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult ListOfPersons()
        {
            //querying from the Person Table
            List<Person> model = (from p in db.Persons
                                  orderby p.PersonID
                                  select p).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Person model)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Person Inserted Succesfully";
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = db.Persons.Find(id);
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Person model)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Update(model);
                db.SaveChanges();
                ViewBag.Message = "Person Updated Succesfully";
            }
            return View(model);
        }
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var model = db.Persons.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = db.Persons.Find(id);
            db.Persons.Remove(model);
            db.SaveChanges();
            TempData["Message"] = "Person Deleted Successfully";
            return RedirectToAction("ListOfPersons");

        }
    }
}
