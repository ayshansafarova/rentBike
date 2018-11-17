using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikely.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Bikely.Controllers
{
	[Authorize]
	public class RoleController : Controller
    {
        //I authorized [Authorize(User.isInRole("Admin"))] - this gave exception
        //NullReferenceObject - in (var item in Model) - iEnumarable<IdneitityRole>?
		ApplicationDbContext context;

		public RoleController()
		{
			context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{

			if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
			{
                var Roles = context.Roles.ToList();
                return View();
            }
			return RedirectToAction("Index", "Home");
		}

        //
        // GET:
		public ActionResult Create()
		{
			if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
			{
                var Role = new IdentityRole();
                return View();
            }
			return RedirectToAction("Index", "Home");
		}

        //
        // POST:
		[HttpPost]
		public ActionResult Create(IdentityRole Role)
		{
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                context.Roles.Add(Role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
		}
	}
}