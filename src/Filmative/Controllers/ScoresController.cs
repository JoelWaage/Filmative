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
using Microsoft.Extensions.Logging.Console;

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
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Scores.Where(x => x.User.Id == currentUser.Id).Include(scores => scores.Movie).ToList());
        }
        public IActionResult Create(int id)
        {
            Score testScore = new Score();
            testScore.Movie = _db.Movies.FirstOrDefault(m => m.MovieId == id);
            return View(testScore);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Score score)
        {
            score.Movie = _db.Movies.FirstOrDefault(m => m.MovieId == score.Movie.MovieId);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            score.User = currentUser;
            _db.Scores.Add(score);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult NewScore(int selectMovie, int newRating, string newReview)
    }
}
