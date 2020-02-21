using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySite1.Auth;
using MySite1.Data;
using MySite1.Models;

namespace MySite1.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public BlogController(ApplicationDbContext db,
            UserManager<User> UM)
        {
            _db = db;
            _userManager = UM;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _db.BlogPosts.OrderByDescending(e => e.Date).Take(30).Include(e => e.CommentsBlog).ToListAsync();
            return View(posts);
        }
        /// <summary>
        /// добавление комментария
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddComment(int postId, string comment)
        {
            if (!string.IsNullOrWhiteSpace(comment))
            {
                // получить псевдоним пользователя
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result.Pseudonym;

                CommentBlog com = new CommentBlog
                {
                    BlogPostId = postId,
                    Body = comment,
                    Author = user,
                    Date = DateTime.Now
                };

                await _db.CommentBlogs.AddAsync(com);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}