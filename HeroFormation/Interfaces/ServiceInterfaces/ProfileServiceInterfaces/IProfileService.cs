using HeroFormation.Data.Entities;
using HeroFormation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.Interfaces.ServiceInterfaces.ProfileServiceInterfaces
{
    public interface IProfileService
    {
        ProfileViewModel RetrieveCurrentUser(string username);
        string GenerateSuperheroName(string firstName, string lastName);
    }
}
