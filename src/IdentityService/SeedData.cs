using System.Security.Claims;
using Duende.IdentityModel;
using IdentityService.Data;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityService;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userMgr.Users.Any()) return;

            var kenneth = userMgr.FindByNameAsync("kenneth").Result;
            if (kenneth == null)
            {
                kenneth = new ApplicationUser
                {
                    UserName = "kenneth",
                    Email = "KennethCheung@test.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(kenneth, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(kenneth, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Kenneth Cheung"),
                            new Claim(JwtClaimTypes.GivenName, "Kenneth"),
                            new Claim(JwtClaimTypes.FamilyName, "Cheung"),
                            new Claim(JwtClaimTypes.WebSite, "http://kenneth.test.com"),
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("kenneth created");
            }
            else
            {
                Log.Debug("kenneth already exists");
            }

            var bob = userMgr.FindByNameAsync("amay").Result;
            if (bob == null)
            {
                bob = new ApplicationUser
                {
                    UserName = "amay",
                    Email = "AmayLeung@test.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Amay Leung"),
                            new Claim(JwtClaimTypes.GivenName, "Amay"),
                            new Claim(JwtClaimTypes.FamilyName, "Leung"),
                            new Claim(JwtClaimTypes.WebSite, "http://amay.test.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("amay created");
            }
            else
            {
                Log.Debug("amay already exists");
            }
        }
    }
}
