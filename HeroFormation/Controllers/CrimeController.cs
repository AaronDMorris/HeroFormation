using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroFormation.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using HeroFormation.Services;

namespace HeroFormation.Controllers
{
    public class CrimeController : Controller
    {
        
        [Authorize]
        public IActionResult Crimes()
        {
                return View();
        }


        [HttpPost]
        public IActionResult GetCrimesByLocation([FromBody]CoordinatesModel model)
        {
            CrimeService crimeService = new CrimeService();

            List<Crimes> crimes = crimeService.GetPrevious6MonthsCrimesByLocationAndDate(model);
 
            return Ok(crimes);
        }
    }
}