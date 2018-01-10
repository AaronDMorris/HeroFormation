using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroFormation.Models;

namespace HeroFormation.Controllers
{
    public class HomeController : Controller
    {
        //Default Index home view
        public IActionResult Index()
        {
            return View();
        }

        //Default error page, left exposed for development purposes
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
