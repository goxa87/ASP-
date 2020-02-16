using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    public class CommentWork : Comment
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int CommentWorkId { get; set; }        
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
