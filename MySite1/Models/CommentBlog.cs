using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    /// <summary>
    /// Комементарий к посту в блоге
    /// </summary>
    public class CommentBlog:Comment
    {
        /// <summary>
        /// ключ комента
        /// </summary>
        public int CommentBlogId { get; set; }

        /// <summary>
        /// ключ поста к кторому привязан комент
        /// </summary>
        public int BlogPostId { get; set; }
    }
}
