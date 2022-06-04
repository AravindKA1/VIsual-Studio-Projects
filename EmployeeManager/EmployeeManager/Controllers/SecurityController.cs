using EmployeeManager.Models;
using EmployeeManager.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;
        public SecurityController(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExistsAsync("Manager").Result)
                {
                    var role = new AppIdentityRole();
                    role.Name = "Manager";
                    role.Decsription = "Can perform CRUD Operation";
                    var roleResult = roleManager.CreateAsync(role).Result;
                }
                var user = new AppIdentityUser();
                user.UserName = register.UserName;
                user.Email = register.Email;
                user.FullName = register.FullName;
                user.BirthDate = register.BirthDate;

                var result = userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                    return RedirectToAction("SignIn", "Security");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user details");
                }
            }
            return View(register);

        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                var result1 = signInManager.PasswordSignInAsync(signIn.UserName, signIn.Password, signIn.RememberMe, false).Result;
                var result = result1;
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "EmployeeManager");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user details");

                }
            }
            return View(signIn);
        }
        
    }
}