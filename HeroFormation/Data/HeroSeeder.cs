using HeroFormation.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.Data
{
    public class HeroSeeder
    {
        private readonly HeroContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public HeroSeeder(HeroContext context,
            IHostingEnvironment hosting,
            UserManager<StoreUser> userManager)
        {
            _context = context;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("s1408926@connect.glos.ac.uk");

            if(user == null)
            {
                user = new StoreUser()
                {
                    SuperHeroName = "Superman",
                    FirstName = "Aaron",
                    LastName = "Morris",
                    UserName = "s1408926@connect.glos.ac.uk",
                    Email = "s1408926@connect.glos.ac.uk"

                };

               var result = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create the default user");
                }
            }
        }
    }
}
