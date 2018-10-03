namespace Bikely.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Bikely.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Bikely.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bikely.Models.ApplicationDbContext context)
        {
            if(!context.Users.Any(u => u.UserName == "ayshan"))
            {
                var roleManager = new RoleManager<IdentityRole>
                    (new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>
                    (new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser
                {
                    UserName = "ayshan",
                    Email = "aysensafarova@gmail.com"
                };
                userManager.Create(user, "@Ayshan1997");
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
