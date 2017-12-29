using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.Data
{
    public class HeroRepository
    {
        private readonly HeroContext _context;

        public HeroRepository(HeroContext context)
        {
            _context = context;
        }

        //public IEnumerable<UserStore> GetAllUsers()
        //{
        //    return _context.Users.ToList();
        //}
    }
}
