using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace WeatherApp.Models.Authentications
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            //userIdentity.AddClaim(new Claim("DefaultLocation", DefaultLocation));
            return userIdentity;
        }

        //Extended Property
        public string DefaultLocation { get; set; }
    }

    //namespace App.Extensions
    //{
    //    public static class IdentityExtensions
    //    {
    //        public static string GetDefaultLocation(this IIdentity identity)
    //        {
    //            return ((ClaimsIdentity)identity).FindFirst("DefaultLocation").Value;
    //        }

    //        public static void SetDefaultLocation(this IIdentity identity, string location)
    //        {

    //            var manager = context.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //            var user = manager.
    //            user.DefaultLocation = location;
    //            manager.Update(user);
    //            context.GetOwinContext().Get<ApplicationDbContext>().SaveChanges();
    //        }
    //    }   
    //}


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("WeatherForcastDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}