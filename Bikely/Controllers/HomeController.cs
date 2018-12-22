using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bikely.Models;

namespace Bikely.Controllers
{
    [AllowAnonymous]
	public class HomeController : Controller
	{
        private ApplicationDbContext context;

		public ActionResult Index()
		{
			return View();
            //this is for bikes list which is read only
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

        public ActionResult Search()
        {
            context = new ApplicationDbContext();
            var list = context.Bikes.Where(x => x.Image != null).ToList();
            return View(list);
        }


	}
}