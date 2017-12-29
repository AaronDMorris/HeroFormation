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

namespace HeroFormation.Controllers
{
    public class CrimeController : Controller
    {
        
        [Authorize]
        public async Task<ActionResult> Crimes()
        {
            string baseUrl = "https://data.police.uk/api/crimes-at-location?date=2016-12&lat=51.860826&lng=-2.248435";
            List<Crimes> crimeInfo = new List<Crimes>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync(baseUrl);

                if (res.IsSuccessStatusCode)
                {
                    var criResponse = res.Content.ReadAsStringAsync().Result;

                    crimeInfo = JsonConvert.DeserializeObject<List<Crimes>>(criResponse);


                }
                return View(crimeInfo);
            }

        }
    }
}