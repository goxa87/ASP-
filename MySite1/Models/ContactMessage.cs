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
        [Required(ErrorMessage = "Не заполенено поле \"от кого\""), MaxLength(100, ErrorMessage = "длинна не более 100 символов")]
        [Display(Name = "От кого")]
        public string From { get; set; }

        public string FromEmail { get; set; }
        /// <summary>
        /// контактная информация
        /// </summary>
        [Display(Name= "Для обратной связи (телефон, месенджер, почта)")]
        public string ContactInfo { get; set; }
        /// <summary>
        /// тело сообщения
        /// </summary>
        [Required(ErrorMessage = "Не введено само сообщение")]
        [Display(Name ="Ваше Сообщение")]
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
