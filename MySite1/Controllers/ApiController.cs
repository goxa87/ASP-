using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySite1.Data;
using MySite1.Models;

namespace MySite1.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ApiController(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Добавление 1 лайка на работу
        /// </summary>
        /// <param name="workId"> ид работы</param>
        /// <returns></returns>
        [HttpGet]
        [Route("worklike/{workId}")]
        public async Task<ActionResult> WorkLike(int workId)
        {
            var work = await _db.Works.FirstOrDefaultAsync(e => e.WorkId == workId);

            if (work == null)
                return NotFound();
            work.Likes++;
            _db.Update(work);
            await _db.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// добавление 1 лайка на пост
        /// </summary>
        /// <param name="postId">id поста</param>
        /// <returns></returns>
        [HttpGet]
        [Route("postlike/{postId}")]
        public async Task<ActionResult> PostLike(int postId)
        {
            var post = await _db.BlogPosts.FirstOrDefaultAsync(e => e.BlogPostId == postId);

            if (post == null)
                return NotFound();
            post.Likes++;
            _db.Update(post);
            await _db.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Возвращает сообщения на платформе
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="notreaden">только непрочитанные (1 - непрочитанные 0 - все)</param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("messages/pass/{password}/notreaden/{notreaden}")]
        //public async Task<ActionResult<List<ContactMessage>>> GetMessages(string password, bool notreaden=true)
        //{
            
        //    if (password != "qwerty123") return StatusCode(401);

        //    var select = await _db.ContactMessages.OrderByDescending(e=>e.Date).ToListAsync();
        //    if (notreaden)
        //    {
        //        return select.Where(e => e.Readen == false).ToList();

        //    }
        //    else return select;
        //}

    }
}