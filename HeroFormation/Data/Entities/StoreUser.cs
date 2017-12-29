using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.Data.Entities
{
    public class StoreUser : IdentityUser
    {
        public string SuperHeroName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
