using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikely.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;

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
            var images = (from bike in context.Bikes
                          where bike.User.Id == uId
                          select bike.Image);
            
            var catNames = (from category in context.Categories
                            join bike in context.Bikes on category.Id
                            equals bike.CategoryId
                            select category.Name);
            ViewData["categories"] = catNames;

            if (User.IsInRole("Owner"))
            {
                return View(list);
            }
            return RedirectToAction("Index", "Home");
        }

        //Get
        public ActionResult New()
        {
            var categories = context.Categories.ToList();
            var viewModel = new BikeFormViewModel
            {
                Categories = categories
            };
  
            return View(viewModel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BikeFormViewModel model)
        {
            var userId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                var categories = context.Categories.ToList();
                var viewModel = new BikeFormViewModel
                {
                    Categories = categories
                };

                return View("New", viewModel);
            }

            byte[] data = new byte[model.BikePhoto.ContentLength];
            model.BikePhoto.InputStream.Read(data, 0, model.BikePhoto.ContentLength);
            TempData["path"] = model.BikePhoto.FileName;

            context.Bikes.Add(new Bike
            {
                Image = data,
                Description = model.Description,
                CategoryId = (byte) model.CategoryId,
                //Category = (Category) model.Categories.Where(c => c.Id == model.CategoryId),
                priceDaily = model.priceDaily,
                priceMonthly = model.priceMonthly,
                priceWeekly = model.priceWeekly,
                isActive = model.isActive,
                User_id = userId
            });
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //public ActionResult New()
        //{

        //}


    }
}