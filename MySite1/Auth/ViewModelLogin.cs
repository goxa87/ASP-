using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Auth
{
    public class ViewModelLogin
    {
        [Required(ErrorMessage ="Не введен логин")] 
        [Display(Name ="Адрес электронной почты")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не введен логин")]
        [DataType(DataType.Password)]
        [Display(Name ="Пароль")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
