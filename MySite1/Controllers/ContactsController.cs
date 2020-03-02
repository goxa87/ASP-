using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySite1.Data;
using MySite1.Models;

namespace MySite1.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class ContactsController : Controller
    {
        public readonly ApplicationDbContext _db;

        public ContactsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(ContactMessage model)
        {
            //валидация на клиенте

            if (ModelState.IsValid)
            {
                model.FromEmail = User.Identity.Name;
                model.Date = DateTime.Now;
                model.Readen = false;

                await _db.ContactMessages.AddAsync(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Contacts");
            }

            return View(model);
            
        }
    }
}