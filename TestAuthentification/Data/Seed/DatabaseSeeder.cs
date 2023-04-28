using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using TestAuthentification.Models;

namespace TestAuthentification.Data.Seed
{
    public class DatabaseSeeder
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public static void Seed(ApplicationDbContext context, RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager)
        {
            // Your seeder code goes here

            if (!_roleManager.Roles.Any())
            {
                var entity1 = new IdentityRole { Name = "Admin" };
                var entity2 = new IdentityRole { Name = "Patient" };
                var entity3 = new IdentityRole { Name = "Medecin" };

                _roleManager.CreateAsync(entity1).GetAwaiter().GetResult();
                _roleManager.CreateAsync(entity2).GetAwaiter().GetResult();
                _roleManager.CreateAsync(entity3).GetAwaiter().GetResult();
            }

            if (!context.Users.Any())
            {
                ApplicationUser applicationUser = new()
                {
                    Email = "senior@gmail.com",
                    UserName = "senior@gmail.com",
                    DisplayName = "Admin"
                };
                //Créer l'utilisateur
                var result = _userManager.CreateAsync(applicationUser, "Passer@123").Result;
                if (result.Succeeded)
                {
                    // Ajouter le role à l'utilisateur
                    var roleAsign = _userManager.AddToRoleAsync(applicationUser, "Admin").Result;
                }
            }
        }
    }
}
