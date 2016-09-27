using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filmative.Models;

namespace Filmative.Controllers
{
    public class UsersController : Controller
    {
        private FilmativeContext db = new FilmativeContext();
        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisUser = db.Users.FirstOrDefault(users => users.UserId == id);
            return View(thisUser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
