using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    public class WorkPicture
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int WorkPictureId { get; set; }
        /// <summary>
        /// название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// индекс сввязи
        /// </summary>
        public int WorkId { get; set; }
        /// <summary>
        /// свойство связи
        /// </summary>
        public Work Work { get; set; }
    }
}
