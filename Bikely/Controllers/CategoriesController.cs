using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Bikely.Models;

namespace Bikely.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext context;

        public CategoriesController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Categories
        public ActionResult Index()
        {
            var list = context.Categories.ToList();
            return View(list);
        }

        //Get
        public ActionResult New()
        { 
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get
        public ActionResult Edit(byte id)
        {
            var cat = context.Categories.SingleOrDefault(c => c.Id == id);
            if(cat == null)
            {
                return View("Error");
            }
            return View(cat);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            var cat = context.Categories.SingleOrDefault(c => c.Id == category.Id);
            if (cat == null)
            {
                return View("Error");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    cat.Name = category.Name;
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
            var cat = context.Categories.SingleOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return View("Error");
            }
            else
            {
                context.Categories.Remove(cat);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}