using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    public class Work
    {   /// <summary>
        /// идентификатор 
        /// </summary>
        public int WorkId { get; set; }
        /// <summary>
        /// заголовок
        /// </summary>
        public string Title{get;set;}
        /// <summary>
        /// описание тело
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ссылка на архив
        /// </summary>
        public string Archive { get; set; }
        /// <summary>
        /// количестыо лайков
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// свойство связи с картинками
        /// </summary>
        public List<WorkPicture> Pictures { get; set; }
        /// <summary>
        /// свойство связи с комментариями
        /// </summary>
        public List<CommentWork> CommentsWork { get; set; }

    }
}
