using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Auth
{
    public class ViewModelRegistration
    {
        [Required(ErrorMessage ="Заполните поле")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Неверный формат")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [DataType(DataType.Password,ErrorMessage ="Неверный формат")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [DataType(DataType.Password, ErrorMessage = "Неверный формат")]
        [Compare(nameof(Password), ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        [MaxLength(128,ErrorMessage ="Превышена максимальная длина")]
        public string Organization { get; set; }

    }
}
