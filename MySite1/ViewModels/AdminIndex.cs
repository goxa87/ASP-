using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySite1.ViewModels
{
    /// <summary>
    /// данные о пользователях для отображения(с целью редактирования)
    /// </summary>
    public class AdminIndex
    {
        public string Email { get; set; }
        public string Pseudonim { get; set; }
        public string Organization { get; set; }
        public List<string> Roles { get; set; }
    }
}
