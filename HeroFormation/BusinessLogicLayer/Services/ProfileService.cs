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

        public string GenerateSuperheroName(string firstName, string lastName)
        {
            string superheroName = "";

            firstName.ToUpper();
            lastName.ToUpper();

            //Generate first superhero name, based on the first letter of ther user's first name
            if (firstName[0] == 'A')
            {
                superheroName += "Captain";
            }
            else if (firstName[0] == 'B')
            {
                superheroName += "Super";
            }
            else if (firstName[0] == 'C')
            {
                superheroName += "Doctor";
            }
            else if (firstName[0] == 'D')
            {
                superheroName += "The Phantom";
            }
            else if (firstName[0] == 'E')
            {
                superheroName += "Ultra";
            }
            else if (firstName[0] == 'F')
            {
                superheroName += "Amazing";
            }
            else if (firstName[0] == 'G')
            {
                superheroName += "Lightning";
            }
            else if (firstName[0] == 'H')
            {
                superheroName += "Giant";
            }
            else if (firstName[0] == 'I')
            {
                superheroName += "Razor";
            }
            else if (firstName[0] == 'J')
            {
                superheroName += "Steel";
            }
            else if (firstName[0] == 'K')
            {
                superheroName += "Ghost";
            }
            else if (firstName[0] == 'L')
            {
                superheroName += "Secret Angent";
            }
            else if (firstName[0] == 'M')
            {
                superheroName += "Agent";
            }
            else if (firstName[0] == 'N')
            {
                superheroName += "Kinetic";
            }
            else if (firstName[0] == 'O')
            {
                superheroName += "Black";
            }
            else if (firstName[0] == 'P')
            {
                superheroName += "The Great";
            }
            else if (firstName[0] == 'Q')
            {
                superheroName += "Major";
            }
            else if (firstName[0] == 'R')
            {
                superheroName += "Professor";
            }
            else if (firstName[0] == 'S')
            {
                superheroName += "Mighty";
            }
            else if (firstName[0] == 'T')
            {
                superheroName += "Crimson";
            }
            else if (firstName[0] == 'U')
            {
                superheroName += "Tough";
            }
            else if (firstName[0] == 'V')
            {
                superheroName += "Iron";
            }
            else if (firstName[0] == 'W')
            {
                superheroName += "Thunder";
            }
            else if (firstName[0] == 'X')
            {
                superheroName += "The Flying";
            }
            else if (firstName[0] == 'Y')
            {
                superheroName += "Wonder";
            }
            else if (firstName[0] == 'Z')
            {
                superheroName += "Space";
            }
            else
            {
                superheroName += "Silver";
            }


            //Generate last superhero name, based on the first letter of ther user's last name
            if (lastName[0] == 'A')
            {
                superheroName += " Gem";
            }
            else if (lastName[0] == 'B')
            {
                superheroName += " Hornet";
            }
            else if (lastName[0] == 'C')
            {
                superheroName += " Wolf";
            }
            else if (lastName[0] == 'D')
            {
                superheroName += " Storm";
            }
            else if (lastName[0] == 'E')
            {
                superheroName += " Master";
            }
            else if (lastName[0] == 'F')
            {
                superheroName += " Cobra";
            }
            else if (lastName[0] == 'G')
            {
                superheroName += " Brain";
            }
            else if (lastName[0] == 'H')
            {
                superheroName += " Knight";
            }
            else if (lastName[0] == 'I')
            {
                superheroName += " Claw";
            }
            else if (lastName[0] == 'J')
            {
                superheroName += " Beast";
            }
            else if (lastName[0] == 'K')
            {
                superheroName += " Master";
            }
            else if (lastName[0] == 'L')
            {
                superheroName += " Viper";
            }
            else if (lastName[0] == 'M')
            {
                superheroName += " Edge";
            }
            else if (lastName[0] == 'N')
            {
                superheroName += " Blaze";
            }
            else if (lastName[0] == 'O')
            {
                superheroName += " Fang";
            }
            else if (lastName[0] == 'P')
            {
                superheroName += " Falcon";
            }
            else if (lastName[0] == 'Q')
            {
                superheroName += " Soldier";
            }
            else if (lastName[0] == 'R')
            {
                superheroName += " Avenger";
            }
            else if (lastName[0] == 'S')
            {
                superheroName += " Wing";
            }
            else if (lastName[0] == 'T')
            {
                superheroName += " Justice";
            }
            else if (lastName[0] == 'U')
            {
                superheroName += " Machine";
            }
            else if (lastName[0] == 'V')
            {
                superheroName += " Guard";
            }
            else if (lastName[0] == 'W')
            {
                superheroName += " Ninja";
            }
            else if (lastName[0] == 'X')
            {
                superheroName += " Arrow";
            }
            else if (lastName[0] == 'Y')
            {
                superheroName += " Ranger";
            }
            else if (lastName[0] == 'Z')
            {
                superheroName += " Ivy";
            }
            else
            {
                superheroName += " Crusader";
            }

            return superheroName;
        }


    }
}
