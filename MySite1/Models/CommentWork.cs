using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    public class CommentWork
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int CommentWorkId { get; set; }
        /// <summary>
        /// автор коментария
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// непосредственно тело коментария
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// дата публикации
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// индекс связи
        /// </summary>
        public int WorkId{get;set;}
        /// <summary>
        /// свойство связи с работой
        /// </summary>
        public Work Work { get; set; }
    }
}
