using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    /// <summary>
    /// сообщение из контактов
    /// </summary>
    public class ContactMessage
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ContactMessageId { get; set; }
        /// <summary>
        /// от кого пришло сообщение
        /// </summary>
        [Required, MaxLength(100)]
        public string From { get; set; }
        /// <summary>
        /// контактная информация
        /// </summary>
        public string ContactInfo { get; set; }
        /// <summary>
        /// тело сообщения
        /// </summary>
        [Required]
        public string Body { get; set; }
        /// <summary>
        /// дата сообщения
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// флаг прочитанности (1 прочитано  0- не прочитано)
        /// </summary>
        public bool Readen { get; set; }

    }
}
