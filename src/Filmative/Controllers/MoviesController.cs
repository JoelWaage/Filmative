using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Filmative.Models;
using Filmative.Models.Repositories;

namespace Filmative.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository movieRepo;

        public MoviesController(IMovieRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.movieRepo = new EFMovieRepository();
            }
            else
            {
                this.movieRepo = thisRepo;
            }
        }

        public ViewResult Index()
        {
            return View(movieRepo.Movies.ToList());
        }
        public IActionResult Details(int id)
        {
            Movie thisMovie = movieRepo.Movies.FirstOrDefault(x => x.MovieId == id);
            return View(thisMovie);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movieRepo.Save(movie);
            return RedirectToAction("Index");
        }
       

        //private FilmativeContext db = new FilmativeContext();
        //public IActionResult Index()
        //{
        //   return View(db.Movies.ToList());
        //}

        //public IActionResult Details(int id)
        //{
        //    var thisMovie = db.Movies.FirstOrDefault(movies => movies.MovieId == id);
        //    return View(thisMovie);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Movie movie)
        //{
        //    db.Movies.Add(movie);
        //    db.SaveChanges();
        //    var thisMovie = movie.MovieId.ToString();
        //    return RedirectToAction(thisMovie, "Movies/Details");
        //}
    }
}
