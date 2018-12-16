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
    [Authorize]
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
        public ActionResult Index()
        {
            var u = User.Identity;
            var uId = u.GetUserId();
            var list = context.Bikes.Where(l => l.User.Id == uId);
            if (User.IsInRole("Owner"))
            {
                return View(list);
            }
            return RedirectToAction("Index", "Home");
        }

        //Get
        public ActionResult New()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                context.Bikes.Add(bike);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        //public ActionResult New()
        //{

        //}


    }
}