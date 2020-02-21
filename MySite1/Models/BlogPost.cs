using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    /// <summary>
    /// модель для записи поста в блог
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int BlogPostId { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Тело поста
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// путь к картинке
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// количество лайков
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// дата публикации поста
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// комментарии к посту
        /// </summary>
        public List<CommentBlog> CommentsBlog { get; set; }
    }
}
