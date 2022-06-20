using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Waggle.Identity;
using Waggle.Models;

namespace Waggle.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<AppIdentityRole> roleManager;
        private readonly SignInManager<AppIdentityUser> signInManager;
        public IdentityController(UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityRole> roleManager, SignInManager<AppIdentityUser> signInManager)
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
                if (!roleManager.RoleExistsAsync("WaggleUser").Result)
                {
                    var role = new AppIdentityRole();
                    role.Name = "WaggleUser";
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
                    userManager.AddToRoleAsync(user, "WaggleUser").Wait();
                    return RedirectToAction("SignIn", "Identity");
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
                    return RedirectToAction("ListOfPersons", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user details");

                }
            }

            return View(signIn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult SignOut()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("SignIn", "Identity");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

