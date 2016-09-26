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
    }
}
