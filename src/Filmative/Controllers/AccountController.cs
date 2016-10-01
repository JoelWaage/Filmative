﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Filmative.Models;

namespace Filmative.Controllers
{
    public class AccountController : Controller
    {
        private readonly FilmativeContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, FilmativeContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        } 
        public IActionResult Index()
        {
            return View();
        }
    }
}
