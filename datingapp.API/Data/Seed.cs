using System.Collections.Generic;
using System.Linq;
using datingapp.API.Data;
using datingapp.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        public static void SeedUsers(datacontext context)
        {
            if (!context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                // var roles = new List<Role>
                // {
                //     new Role{Name = "Member"},
                //     new Role{Name = "Admin"},
                //     new Role{Name = "Moderator"},
                //     new Role{Name = "VIP"},
                // };

                // foreach (var role in roles)
                // {
                //     roleManager.CreateAsync(role).Wait();
                // }

                foreach (var user in users)
                {
                    byte[] passwordhash, passwordSalt;
                    CreatePasswordHash("password", out passwordhash, out passwordSalt);

                    user.PasswordHash = passwordhash;
                    user.PasswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();
                    context.Users.Add(user);
                    // user.Photos.SingleOrDefault().IsApproved = true;
                    // userManager.CreateAsync(user, "password").Wait();
                    // userManager.AddToRoleAsync(user, "Member").Wait();
                }
                context.SaveChanges();
                // var adminUser = new User
                // {
                //     UserName = "Admin"
                // };

                // IdentityResult result = userManager.CreateAsync(adminUser, "password").Result;

                // if (result.Succeeded)
                // {
                //     var admin = userManager.FindByNameAsync("Admin").Result;
                //     userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator"}).Wait();
                // }
            }
        }
         private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); 
            }
        }
    }
}