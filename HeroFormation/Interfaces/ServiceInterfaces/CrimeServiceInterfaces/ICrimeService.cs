using HeroFormation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.Interfaces.Services.CrimeService
{
    public interface ICrimeService
    {
        List<Crimes> GetPrevious6MonthsCrimesByLocationAndDate(CoordinatesModel model);

    }
}
