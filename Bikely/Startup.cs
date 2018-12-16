using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Bikely.Models;
using Owin;
using System.Security.Claims;

[assembly: OwinStartupAttribute(typeof(Bikely.Startup))]
namespace Bikely
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			createUserRoles();
		}


		// In this method I will create default User roles and Admin user for login
		private void createUserRoles()
		{
			//ApplicationDbContext context = new ApplicationDbContext();

			//var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			//var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

   //         if (!rolemanager.roleexists("admin"))
   //         {
   //             var role = new identityrole();
   //             role.name = "admin";
   //             rolemanager.create(role);
   //         }

   //         if (!roleManager.RoleExists("Owner"))
			//{
			//	var role = new IdentityRole();
			//	role.Name = "Owner";
			//	roleManager.Create(role);

			//}
            
			//if (!roleManager.RoleExists("Renter"))
			//{
			//	var role = new IdentityRole();
			//	role.Name = "Renter";
			//	roleManager.Create(role);

			//}
		}
	}
}
