using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySite1.Models;

namespace MySite1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TestPost() => View();

        //[HttpPost]
        //public IActionResult TestPost(TestModel model)
        //{
        //    if (string.IsNullOrEmpty(model.StringField) || model.StringField.Length < 5)
        //        ModelState.AddModelError("", "общая ошибка. длинна мен 5 ");

        //    if (ModelState.IsValid)
        //    {
        //        return Content($"{model.BoolField} - {model.DateField.ToShortDateString()}- {model.Intfield} - {model.StringField}");
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}

        public int TestPost(int t)
        {
            _logger.LogWarning(111, $"это тело сообщения значение - {t}");
            return 108;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
