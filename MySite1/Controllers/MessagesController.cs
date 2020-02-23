using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySite1.Auth;

namespace MySite1.Controllers
{
    public class MessagesController : Controller
    {

        private readonly UserManager<User> _userManager;

        public MessagesController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.Pseudonim = user.Pseudonym;
            return View();
        }
    }
}