using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Weatherex.Infrastructure.Identity;

namespace Weatherex.Infrastructure.Persistence
{
    public static class DbSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser
            {
                UserName = "rick",
                Email = "rick@earth.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(x => x.UserName != user.UserName))
            {
                await userManager.CreateAsync(user, "!Sanchez1");
            }
        }
    }
}
