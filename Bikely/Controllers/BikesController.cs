using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikely.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bikely.Controllers
{
    [Authorize(Roles = "Owner")]
    public class BikesController : Controller
    {
        private ApplicationDbContext context;

        public BikesController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Bikes
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole("Owner"))
            {
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult New()
        //{

        //}


}
}