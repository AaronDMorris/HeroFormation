using HeroFormation.Data.Entities;
using HeroFormation.Interfaces.ServiceInterfaces.ProfileServiceInterfaces;
using HeroFormation.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroFormation.BusinessLogicLayer.Services
{
    public class ProfileService: IProfileService
    {
        private readonly UserManager<StoreUser> _userManager;

        public ProfileService(UserManager<StoreUser> userManager)
        {
            _userManager = userManager;
        }

        public ProfileViewModel RetrieveCurrentUser(string username)
        {

            var user = _userManager.FindByNameAsync(username).Result;

            ProfileViewModel userViewmodel = new ProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                SuperHeroName = user.SuperHeroName,
                UserName = user.UserName,
                Email = user.Email
            };

            return userViewmodel;

        }


    }
}
