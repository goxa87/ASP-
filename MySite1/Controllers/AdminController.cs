using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySite1.Auth;
using MySite1.ViewModels;

namespace MySite1.Controllers
{
    [Authorize(Roles = "administrator, moderator")]
    public class AdminController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<User> UM,
            RoleManager<IdentityRole> RM)
        {
            _userManager = UM;
            _roleManager = RM;
        }
        [Authorize]
        public IActionResult Index()
        {
            // нужен класс
            List<AdminIndex> list = new List<AdminIndex>();

            var users = _userManager.Users.ToList();

            foreach (var e in users)
            {
                // получить ролия для этого пользователя
                var roles = new List<string>();
                foreach (var i in _userManager.GetRolesAsync(e).Result)
                {
                    // добавить во временный список
                    roles.Add(i);
                }

                list.Add(new AdminIndex
                {
                    Email = e.Email,
                    Pseudonim = e.Pseudonym,
                    Organization = e.Organization,
                    Roles = roles
                }) ;
            }
            return View(list);
        }

        public ActionResult AddWork() => View();
        public ActionResult AddPost() => View();

        /// <summary>
        /// добавление роли администратора
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles ="administrator")]
        public async Task<ActionResult> AddRoleAdmin(string userName)
        {
            string roleName = "administrator";

            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role == null)
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                role = await _roleManager.FindByNameAsync(roleName);
                var rezult = await _userManager.AddToRoleAsync(user, role.Name);
            }
            return RedirectToAction("index");
        }
        /// <summary>
        /// добавление к пользователю роли администратора
        /// </summary>
        /// <param name="userName">логин пользователя - электронная почта</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "administrator")]
        public async Task<ActionResult> AddRoleModerator(string userName)
        {
            string roleName = "moderator";
            //получаем пользователя
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                // ищем роль
                var role = await _roleManager.FindByNameAsync(roleName);
                //если нет создаем
                if (role == null)
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                role = await _roleManager.FindByNameAsync(roleName);
                //добавляем непосредственно
                var rezult = await _userManager.AddToRoleAsync(user, role.Name);
            }
            return RedirectToAction("index");
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "administrator")]        
        public async Task<ActionResult> DeleteUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                // защита от дуракак чтоб себя не удалить
                if(userName==User.Identity.Name)
                    return RedirectToAction("index");
                var rezult = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("index");
        }
    }
}