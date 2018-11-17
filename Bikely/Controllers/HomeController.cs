using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bikely.Controllers
{
    [AllowAnonymous]
	public class HomeController : Controller
	{
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
	}
}