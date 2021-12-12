using Abc.UI.Entities;
using Abc.UI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI.Controllers
{
    public class AccountController : Controller
    {
        UserManager<CustomIdentityUser> _userManager;
        RoleManager<CustomIdentityRole> _roleManager;
        SignInManager<CustomIdentityUser> _signInManager;
        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };
                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result; //Kullanıcı Oluşturma
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("Admin").Result) //Role Oluşturma
                    {
                        CustomIdentityRole role = new CustomIdentityRole()
                        {
                            Name = "Admin"
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We cannot role admin role");
                            return View(registerViewModel);
                        }
                    }
                }
                _userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("Login", "Account");
            }
            return View(registerViewModel);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName,loginViewModel.Password,loginViewModel.RememberMe,false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Admin");
                }
                ModelState.AddModelError("","Invalid login");
            }
            return View(loginViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
    }
}
