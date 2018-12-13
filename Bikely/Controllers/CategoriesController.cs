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
            return View();
        }

        //Get
        public ActionResult New()
        {
            return View();
        }

        //Post
        //public ActionResult New(Category model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}
    }
}