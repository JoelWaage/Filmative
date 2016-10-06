using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Filmative.Models;

namespace Filmative.Controllers
{
    [Authorize]
    public class ScoresController : Controller
    {
        private readonly FilmativeContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ScoresController (UserManager<ApplicationUser> userManager, FilmativeContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Scores.Where(x => x.User.Id == currentUser.Id).Include(scores => scores.Movie).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Movie = new SelectList(_db.Movies, "MovieId", "Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Score score)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            score.User = currentUser;
            _db.Scores.Add(score);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
