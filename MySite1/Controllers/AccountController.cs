using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySite1.Auth;

namespace MySite1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> UM, SignInManager<User> SIM)
        {
            _userManager = UM;
            _signInManager = SIM;
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
            }

            ModelState.AddModelError("", "Что-то неправильно(");
            return View(model);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(ViewModelRegistration model)
        {
            if (ModelState.IsValid)
            {

                var user = new User
                {
                    Pseudonym = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Organization = model.Organization
                };

                var createResult = _userManager.CreateAsync(user, model.Password);

                if (createResult.Result.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);
                    return RedirectToAction("Index", "Home");
                }
                else//иначе
                {
                    foreach (var identityError in createResult.Result.Errors)
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