using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace F15Team26.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AppUser : IdentityUser
    {
     
        //TODO: Put any additional fields that you need for your user here
        //For instance
        //DONE
        public string FName { get; set; }
        public string MI { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string States { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string CreditCard1 { get; set; }
        public string CreditCard1Type { get; set; }
        public string CreditCard2 { get; set; }
        public string CreditCard2Type { get; set; }
        public string CreditCard3 { get; set; }
        public string CreditCard3Type { get; set; }
        
        
        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    //TODO: Here's your db context for the project.  All of your db sets should go in here
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        //TODO:  Add dbsets here, for instance there's one for books
        //Remember, Identity adds a db set for users, so you shouldn't add that one - you will get an error
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        
        public AppDbContext()
            : base("MyDBConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public System.Data.Entity.DbSet<F15Team26.Models.AppRole> AppRoles { get; set; }
    }
}