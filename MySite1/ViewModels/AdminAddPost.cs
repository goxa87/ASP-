using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.ViewModels
{
    /// <summary>
    /// модель для формы добавления поста
    /// </summary>
    public class AdminAddPost
    {
        /// <summary>
        /// заголовок
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// тело
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// картинка
        /// </summary>
        public IFormFile Picture { get; set; }
    }
}
