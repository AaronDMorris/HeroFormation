﻿using HeroFormation.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.Data
{
    public class HeroContext : IdentityDbContext<StoreUser>
    {
        public HeroContext(DbContextOptions<HeroContext> options): base(options)
        {
        }
     
        //public DbSet<StoreUser> Users { get; set; }
    }
}