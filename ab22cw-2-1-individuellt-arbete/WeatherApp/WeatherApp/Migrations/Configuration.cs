using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WeatherApp.Models.Authentications;

namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WeatherApp.Models.Authentications.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WeatherApp.Models.Authentications.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "andreas@bom.se"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "andreas@bom.se",
                    Email = "andreas@bom.se"
                };

                manager.Create(user, "ettdv409");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    
    }
}
