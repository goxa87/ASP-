using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Auth
{
    public class ViewModelRegistration
    {
        [Required(ErrorMessage ="Заполните поле Псевдоним")]
        [Display(Name ="Псевдоним (видим для других пользователей)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле Электронная почта")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Неверный формат электронной почты")]
        [Display(Name="Электронная почта (по этой почте будет вход)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните поле пароль")]
        [DataType(DataType.Password)]
        [Display(Name="Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Заполните поле Повторите пароль")]
        [DataType(DataType.Password, ErrorMessage = "Неверный формат")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        [Display(Name = "Повторите Пароль")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Заполните поле (128 символов макс.)")]
        [MaxLength(128,ErrorMessage ="Превышена максимальная длина")]
        public string Organization { get; set; }
    }
}
