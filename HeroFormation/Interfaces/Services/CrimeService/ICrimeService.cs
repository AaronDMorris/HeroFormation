using HeroFormation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.Interfaces.Services.CrimeService
{
    interface ICrimeService
    {
        List<Crimes> GetPrevious6MonthsCrimesByLocationAndDate(CoordinatesModel model);

    }
}
