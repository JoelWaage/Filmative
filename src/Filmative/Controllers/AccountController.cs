﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Filmative.Models;
using Filmative.ViewModels;

namespace Filmative.Controllers
{
    public class AccountController : Controller
    {
        private readonly FilmativeContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, FilmativeContext db )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        } 
        
        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.UserName };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}