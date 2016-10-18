using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Filmative.Models;
using Filmative.Models.Repositories;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public ActionResult Index(string movieGenre, string searchString)
        {
            var GenreList = new List<string>();

            var GenreQuery = from d in movieRepo.Movies
                             orderby d.Genre
                             select d.Genre;

            GenreList.AddRange(GenreQuery.Distinct());
            ViewBag.movieGenre = new SelectList(GenreList);

            var movies = from m in movieRepo.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));   
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            
            return View(movies);
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
            string title = movie.Title;
            var thisMovie = Movie.GetMovie(title);
            movieRepo.Save(thisMovie);
            string thisId = thisMovie.MovieId.ToString();
            return RedirectToAction(thisId, "Movies/Details");
        }

        public IActionResult GetMovie()
        {
            string ad = "Arizona Dream";
            var arizonaDream = Movie.GetMovie(ad);
            return View(arizonaDream);
        }
    }
}
