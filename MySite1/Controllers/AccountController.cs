using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySite1.Auth;

namespace MySite1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> UM,
            SignInManager<User> SIM,
            RoleManager<IdentityRole> RM
            )
        {
            _userManager = UM;
            _signInManager = SIM;
            _roleManager = RM;
        }


        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(ViewModelLogin model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неверные данные");
            }
            return View(model);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(ViewModelRegistration model)
        {
            
            if ( !string.IsNullOrWhiteSpace(model.Email) && await _userManager.Users.AnyAsync(e => e.Email.ToLower() == model.Email.ToLower()))
                ModelState.AddModelError("", "Пользователь с такой электронной почтой уже существует");

            if (!string.IsNullOrWhiteSpace(model.Name) && await _userManager.Users.AnyAsync(e => e.Pseudonym.ToLower() == model.Name.ToLower()))
                ModelState.AddModelError("", "Пользователь с таким псевдонимом уже существует");

            if (ModelState.IsValid)
            {

                var user = new User
                {
                    Pseudonym = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Organization = model.Organization
                };

                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync("user");

                    if (role == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("user"));
                    }

                    role = await _roleManager.FindByNameAsync("user");

                    var roleAdmin = await _roleManager.FindByNameAsync("administrator");

                    if (roleAdmin == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole("administrator"));
                    }

                    roleAdmin = await _roleManager.FindByNameAsync("administrator");

                    if (model.Email == "goxa87@rambler.ru")
                    {
                        await _userManager.AddToRoleAsync(user, roleAdmin.Name);
                    }

                    await _userManager.AddToRoleAsync(user, role.Name);
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else//иначе
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}