using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ReviewerProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Game classes
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Eidolon> Eidolons { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Quest> Quests { get; set; }

        //App classes
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}