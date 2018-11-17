using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Bikely.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bikely.Controllers
{
	[Authorize]
	public class UsersController : Controller
    {
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				if (User.IsInRole("Admin"))
                {
                    ViewBag.Role = "Admin";
				}
                else
                {
                    ViewBag.Role = "Not Admin";
                }
				return View();
			}
			else
			{
                return RedirectToAction("Index", "Home");
			}
		}
	}
}