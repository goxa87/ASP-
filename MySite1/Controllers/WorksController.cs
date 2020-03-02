using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySite1.Auth;
using MySite1.Data;
using MySite1.Models;

namespace MySite1.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class WorksController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public WorksController(ApplicationDbContext db,
            UserManager<User> UM)
        {
            _db = db;
            _userManager = UM;
        }


        public IActionResult Index()
        {
            var works = _db.Works.Include(u => u.Pictures).Include(e=>e.CommentsWork).ToList();
            return View(works);
        }
        /// <summary>
        /// добавить коментарий
        /// </summary>
        /// <param name="workId">id работы</param>
        /// <param name="comment">тело коментария</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddComment(int workId, string comment)
        {
            if(!string.IsNullOrWhiteSpace(comment))
            {
                // получить псевдоним пользователя
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var name = user.Pseudonym;
                CommentWork com = new CommentWork
                {
                    WorkId = workId,
                    Body = comment,
                    Author = name,
                    Date = DateTime.Now
                };

                await _db.CommentWorks.AddAsync(com);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        
        [Authorize]
        public FileResult DownloadWork(string path, string name) 
            => File(path, "Application/rar", name+".rar");
    }
}