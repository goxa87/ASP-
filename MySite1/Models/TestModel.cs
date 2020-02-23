using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.Models
{
    /// <summary>
    /// тестовый класс для экспериментов
    /// </summary>
    public class TestModel
    {
        public int TestModelId { get; set; }
        [Required(ErrorMessage = "не указано это поле")]
        [Display(Name ="текстовое поле")]
        public string StringField { get; set; }
        [Required(ErrorMessage = "не указано это поле")]
        [Display(Name = "число поле")]
        [Range(1,10,ErrorMessage ="неопустимый интервал")]
        public int Intfield { get; set; }
        [Display(Name = "дата поле")]
        public DateTime DateField { get; set; }

        public bool BoolField { get; set; }
    }
}
