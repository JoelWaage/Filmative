using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Filmative.Models;

namespace Filmative.Controllers
{
    [Authorize]
    public class ScoresController : Controller
    {
        private readonly FilmativeContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ScoresController(UserManager<ApplicationUser> userManager, FilmativeContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
