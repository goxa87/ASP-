using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySite1.Auth;
using MySite1.Data;
using MySite1.Models;
using MySite1.ViewModels;

namespace MySite1.Controllers
{
    [Authorize(Roles = "administrator, moderator")]
    [AutoValidateAntiforgeryToken]
    public class AdminController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _hostEnviromnent;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<User> UM,
            RoleManager<IdentityRole> RM,
            IWebHostEnvironment environment,
            ApplicationDbContext context)
        {
            _userManager = UM;
            _roleManager = RM;
            _hostEnviromnent = environment;
            _context = context;
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
                });
            }
            return View(list);
        }        

        /// <summary>
        /// добавление роли администратора
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "administrator")]
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
                if (userName == User.Identity.Name)
                    return RedirectToAction("index");
                var rezult = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("index");
        }

        /// *************************************************************************** addWork
        [HttpGet]
        [Authorize(Roles = "administrator")]
        public ActionResult AddWork() => View();
        [HttpPost]
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> AddWork(AdminAddWork work)
        {
            // создать непосредственно ворк
            var newWork = new Work
            {
                Title = work.Title,
                Description = work.Description,
                Likes = 0,
                Pictures=new List<WorkPicture>()
            };

            //сохр файл
            if (work.Archive != null)
            {
                string archivePath = string.Concat( "/Works/", work.Archive.FileName);
                using (var FS = new FileStream(_hostEnviromnent.WebRootPath + archivePath, FileMode.Create))
                {
                    await work.Archive.CopyToAsync(FS);
                }
                //добавление пути для поиска файла
                newWork.Archive = archivePath;
            }
            //сохр фотки
            foreach (var e in work.pictures)
            {
                if (e != null)
                {
                    string picName = String.Concat("/WorksPictures/", e.FileName);
                    using (var FS = new FileStream(_hostEnviromnent.WebRootPath + picName, FileMode.Create))
                    {
                        await e.CopyToAsync(FS);
                    }

                    newWork.Pictures.Add(new WorkPicture {
                        Name = picName
                    });
                }
            }
            //сохр тело
            await _context.Works.AddAsync(newWork);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        // ******************************************************* доб поста
        [HttpGet]
        [Authorize(Roles = "administrator")]
        public ActionResult AddPost() => View();
        [HttpPost]
        [Authorize(Roles = "administrator")]
        public async Task<ActionResult> AddPost(AdminAddPost model)
        {
            var post = new BlogPost
            {
                Title=model.Title,
                Body = model.Body,
                Date = DateTime.Now,
                Likes =0
            };

            if (model.Picture != null)
            {
                string picName = String.Concat("/BlogPictures/",DateTime.Now.ToShortDateString(), model.Picture.FileName);
                using (var FS = new FileStream(_hostEnviromnent.WebRootPath + picName, FileMode.Create))
                {
                    await model.Picture.CopyToAsync(FS);
                }

                post.Image = picName;
            }
            else 
            {
                post.Image = "/BlogPictures/defaultMe.jpg";
            }
            await _context.BlogPosts.AddAsync(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Blog");
        }

        // *********************************************** сообщения
        [HttpGet]
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> MyMessages()
        {
            var messages = await _context.ContactMessages.OrderBy(e => e.Readen).ThenByDescending(e => e.Date).ToListAsync();
            return View(messages);
        }

        public async Task<IActionResult> ShowMessage(int messageId)
        {
            var message = await _context.ContactMessages.FirstOrDefaultAsync(e => e.ContactMessageId == messageId);
            message.Readen = true;
            await _context.SaveChangesAsync();
            
            return View(message);
        }




    }
}