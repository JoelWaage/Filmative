﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filmative.Models;


namespace Filmative.Controllers
{
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TestAjax()
        {
            return Content("AJAX is connected", "text/plain");
        }
    }
}
