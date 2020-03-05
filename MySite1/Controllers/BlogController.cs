using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySite1.Auth;
using MySite1.Data;
using MySite1.Models;

namespace MySite1.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;

        public BlogController(ApplicationDbContext db,
            UserManager<User> UM,
            ILogger<HomeController> logger)
        {
            _db = db;
            _userManager = UM;
            _logger = logger;
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
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var name = user.Pseudonym;
                CommentBlog com = new CommentBlog
                {
                    BlogPostId = postId,
                    Body = comment,
                    Author = name,
                    Date = DateTime.Now
                };

                await _db.CommentBlogs.AddAsync(com);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Добавляет лайки в работы и посты(надоб вынести в апи контроллер).
        /// </summary>
        /// <param name="postId">id записи.</param>
        /// <param name="type">Тип события.</param>
        /// <returns>Частичное представление</returns>
        public async Task<PartialViewResult> MakeLike(int postId, string type)
        {

            _logger.LogWarning(777, $"id of post: {postId} - type ={type}");

            int likesValue = 0;

            // для страницы поста.
            if (type == "post")
            {
                // Извлекаем по id.
                var post = await _db.BlogPosts.FirstOrDefaultAsync(e => e.BlogPostId == postId);
                // Проверка на нуль.
                if (post == null)
                {
                    ViewBag.Rezult = "Чтото не так с загрузкой события(";
                    return PartialView();
                }
                // Вычисления и сохранения в БД.
                likesValue = ++post.Likes;
                _db.BlogPosts.Update(post);
                await _db.SaveChangesAsync();
            }
            else 
            {
                // для страницы работы.
                // Извлекаем по id.
                var work = await _db.Works.FirstOrDefaultAsync(e => e.WorkId == postId);
                // Проверка на нуль.
                if (work == null)
                {
                    ViewBag.Rezult = "Чтото не так с загрузкой работы(";
                    return PartialView();
                }
                // Вычисления и сохранения в БД.
                likesValue = ++work.Likes;
                _db.Works.Update(work);
                await _db.SaveChangesAsync();
            }
            // Возвращвем результат
            ViewBag.Rezult = $"Вам понравилось! всего: {likesValue}";
            return PartialView();
        }
    }
}