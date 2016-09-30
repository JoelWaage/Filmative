using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Filmative.Models;

namespace Filmative.Controllers
{
    public class ScoresController : Controller
    {
        private FilmativeContext db = new FilmativeContext();
        public IActionResult Index()
        {
            return View(db.Scores.Include(score => score.Movie).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisScore = db.Scores.FirstOrDefault(scores => scores.ScoreId == id);
            return View(thisScore);
        }
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Title");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Score score)
        {
            db.Scores.Add(score);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
