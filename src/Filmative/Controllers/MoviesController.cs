﻿using System;
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

        public IActionResult ScorePartial()
        {
            return View();
        }

        public IActionResult GetMovie()
        {
            var greenValley = Movie.GetMovie();
            return View(greenValley);
        }
    }
}
