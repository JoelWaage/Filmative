using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filmative.Models;

namespace Filmative.Controllers
{
    public class MoviesController : Controller
    {
        private FilmativeContext db = new FilmativeContext();
        public IActionResult Index()
        {
           return View(db.Movies.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisMovie = db.Movies.FirstOrDefault(movies => movies.MovieId == id);
            return View(thisMovie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            var thisMovie = movie.MovieId.ToString();
            return RedirectToAction(thisMovie, "Movies/Details");
        }
    }
}
