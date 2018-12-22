using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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

            var list1 = context.Bikes.Where(l => l.User_id == uId).Include(l => l.Category);
            var list2 = context.Bikes.Where(x => x.User_id != null).Include(l => l.Category);
            var images = (from bike in context.Bikes
                          where bike.User.Id == uId
                          select bike.Image);
            var list3 = context.Bikes.Where(x => x.User_id != null).ToList();

            if (User.IsInRole("Owner"))
            {
                return View(list1);
            }
            else if(User.IsInRole("Admin"))
            {
                return View(list2);
            }
            else if (User.IsInRole("Renter"))
            {
                return View(list3);
            }
            return RedirectToAction("Index", "Home");
        }

        //Get: Bikes/id
        public ActionResult Selected(int id)
        {
            var u = User.Identity;
            var uId = u.GetUserId();

            var bike = context.Bikes.Where(l => l.Id == id).Include(l => l.Category);

            if (User.IsInRole("Renter"))
            {
                return View(bike);
            }
            return RedirectToAction("Index", "Home");
        }

        //get
        [AllowAnonymous]
        public ActionResult Search()
        {
            var list3 = context.Bikes.Where(x => (x.User_id != null) && (x.isActive == true)).ToList();
            return View(list3);
        }
        //Get
        public ActionResult New()
        {
            if (User.IsInRole("Owner"))
            {
                var categories = context.Categories.ToList();
                var viewModel = new BikeFormViewModel
                {
                    Categories = categories
                };

                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
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
            //TempData["path"] = model.BikePhoto.FileName;

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

        //Get
        public ActionResult Edit(byte id)
        {
            if (User.IsInRole("Owner"))
            {
                var bike = context.Bikes.SingleOrDefault(c => c.Id == id);
                if (bike == null)
                {
                    return View("Error");
                }

                var viewmodel = new BikeFormViewModel(bike)
                {
                    Categories = context.Categories.ToList()
                };

                //ViewBag.Data = imgData;
                return View(viewmodel);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BikeFormViewModel model)
        {
            string uId = User.Identity.GetUserId();
            var _bike = context.Bikes.SingleOrDefault(c => c.Id == model.Id);
            if (_bike == null)
            {
                return View("Error");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    byte[] data = new byte[model.BikePhoto.ContentLength];
                    //if(data == null)
                    //{
                        
                    //}
                    model.BikePhoto.InputStream.Read(data, 0, model.BikePhoto.ContentLength);

                    _bike.Description = model.Description;
                    _bike.Image = data;
                    _bike.isActive = model.isActive;
                    _bike.priceDaily = model.priceDaily;
                    _bike.priceWeekly = model.priceWeekly;
                    _bike.priceMonthly = model.priceMonthly;
                    _bike.CategoryId = (byte) model.CategoryId;
                    _bike.User_id = uId;

                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("Error");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var bike = context.Bikes.SingleOrDefault(c => c.Id == id);
            if (bike == null)
            {
                return View("Error");
            }
            else
            {
                context.Bikes.Remove(bike);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}