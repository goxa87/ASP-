using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    public class Comment
    {
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
    }
}
