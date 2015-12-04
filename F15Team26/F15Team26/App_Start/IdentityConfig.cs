using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using F15Team26.Models;

namespace F15Team26
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class IdentityConfig{
    //public void Configuration(IAppBuilder app) {
      //  app.CreatePerOwinContext<AppDbContext>(AppDbContext.Create);
        //app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
        //app.CreatePerOwinContext<AppRoleManager>(AppRoleManager.Create);
        //app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login"),});
    }
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }


        //TODO:  Change any settings related to your user password rules, etc.
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context) 
        {
            var manager = new AppUserManager(new UserStore<AppUser>(context.Get<AppDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                //TODO: If you want to use email as the username, you need to make sure usernames can have @ 
                //and that each person has a unique email
                //done
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // TODO: Configure validation logic for passwords
            //done
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<AppUser, string>
    {
        public ApplicationSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AppUser user)
        {
            return user.GenerateUserIdentityAsync((AppUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }
    }
}
