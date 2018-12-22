using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikely.Models;
using System.Data.Entity;

namespace Bikely.Controllers
{
    [Authorize]
    public class RentalsController : Controller
    {
        private ApplicationDbContext context;
        private string _bikeId;

        public RentalsController()
        {
            context = new ApplicationDbContext();
            context.Configuration.ProxyCreationEnabled = false;
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Rentals
        public ActionResult Index()
        {
            var u = User.Identity;
            var uId = u.GetUserId();

            var list1 = context.Rentals.Where(l => l.User_id == uId).Include(l => l.Bike);
            var list2 = context.Rentals.Include(l => l.Bike).Include(l => l.Renter).ToList();
            var list3 = context.Rentals.Include(l => l.Bike);

            if (User.IsInRole("Owner"))
            {
                return View(list2);
            }
            else if (User.IsInRole("Renter"))
            {
                return View(list1);
            }
            else if (User.IsInRole("Admin"))
            {
                return View(list3);
            }
            return RedirectToAction("Index", "Home");
        }

        //Get
        public ActionResult New(int bikeId)
        {
            var bike = context.Bikes.SingleOrDefault(b => b.Id == bikeId);
            if (bike == null)
            {
                return View("Error");
            }

            _bikeId = Convert.ToString(bike.Id);

            if (User.IsInRole("Renter"))
            {
                var viewModel = new RentalFormViewModel
                {
                    Bikeİd = bike.Id
                };
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                
                    //var bike = context.Bikes.SingleOrDefault(b => b.Id == bikeId);
                    //var viewModel = new RentalFormViewModel
                    //{
                    //    Bikeİd = bike.Id
                    //};
                    //return View("New",model);
                    return RedirectToAction("New", _bikeId);
            }


                context.Rentals.Add(new Rental
                {
                    Message = model.Message,
                    BikeId = (int)model.Bikeİd,
                    isAccepted = false,
                    EndDate = model.EndDate,
                    StartDate = model.StartDate,
                    User_id = User.Identity.GetUserId()
                });
                context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        //Get
        public ActionResult Edit(int rentalId, int bikeId)
        {
            var rental = context.Rentals.SingleOrDefault(r => r.Id == rentalId);
            if (rental == null)
            {
                return View("Error");
            }

            var viewModel = new RentalFormViewModel(rental)
            {
                Bikeİd = rental.BikeId
            };
            
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RentalFormViewModel model)
        {
            string uId = User.Identity.GetUserId();
            var _rental = context.Rentals.SingleOrDefault(c => c.Id == model.Id);
            if (_rental == null)
            {
                return View("Error");
            }
            else
            {
                //if (ModelState.IsValid)
                //{
                    _rental.EndDate = model.EndDate;
                    _rental.StartDate = model.StartDate;
                    _rental.Message = model.Message;
                    _rental.isAccepted = model.isAccepted;
                    _rental.BikeId = (int) model.Bikeİd;
                    _rental.User_id = model.Renter.Id;

                    context.SaveChanges();
                    return RedirectToAction("Index");
                //}
            }
            return View("Error");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var rental = context.Rentals.SingleOrDefault(r => r.Id == id);
            if (rental == null)
            {
                return View("Error");
            }
            else
            {
                context.Rentals.Remove(rental);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}