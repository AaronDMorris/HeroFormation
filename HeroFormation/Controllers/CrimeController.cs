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
        //Default Crimes view returned via this method - only accessible by a logged in user
        [Authorize]
        public IActionResult Crimes()
        {
                return View();
        }

        //This method recieves the HTTP post sent from the client side. A CoordinatesModel is generated with the user's current location and returned as an IActionResult
        [HttpPost]
        public IActionResult GetCrimesByLocation([FromBody]CoordinatesModel model)
        {
            CrimeService crimeService = new CrimeService();

            List<Crimes> crimes = crimeService.GetPrevious6MonthsCrimesByLocationAndDate(model);
 
            return Ok(crimes);
        }
    }
}