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
        public int logCounter;
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> uManager;

        public UsersController()
        {
            logCounter = 0;
            context = new ApplicationDbContext();
            uManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                logCounter++;
                ViewBag.Count = logCounter.ToString();

                //Identity User List with LINQ
                if (User.IsInRole("Admin"))
                {
                    ViewBag.Role = "Admin";
                    var users = (from user in context.Users
                                 where user.Email != "aysensafarova@gmail.com" &&
                                 user.UserName != "ayshan"
                                 select new
                                 {
                                     id = user.Id,
                                     name = user.UserName,
                                     email = user.Email,
                                     phone = user.PhoneNumberConfirmed,
                                     roles = (from userRole in user.Roles
                                              join role in context.Roles on userRole.RoleId
                                              equals role.Id
                                              select role.Name
                                             ).ToList()
                                 }).ToList().Select(f => new UsersViewModel()
                                 {
                                     userId = f.id,
                                     userName = f.name,
                                     userEmail = f.email,
                                     phoneNumConfirmed = f.phone,
                                     roleName = String.Join(",", f.roles),
                                     showSomeParts = true
                                 });
                    return View(users);
                }
                else
                {
                    ViewBag.Role = "Not Admin";
                    var users = (from user in context.Users
                                 where user.Email != "aysensafarova@gmail.com" &&
                                 user.UserName != "ayshan"
                                 select new
                                 {
                                     id = user.Id,
                                     name = user.UserName,
                                     email = user.Email,
                                     phone = user.PhoneNumberConfirmed,
                                     roles = (from userRole in user.Roles
                                              join role in context.Roles on userRole.RoleId
                                              equals role.Id
                                              select role.Name
                                             ).ToList()
                                 }).ToList().Select(f => new UsersViewModel()
                                 {
                                     userId = f.id,
                                     userName = f.name,
                                     userEmail = f.email,
                                     phoneNumConfirmed = f.phone,
                                     roleName = String.Join(",", f.roles),
                                     showSomeParts = false
                                 });
                    return View(users);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //Get:
        public ActionResult Delete(string userId)
        {
            if (User.IsInRole("Admin"))
            {
                if(userId == null)
                {
                    return View("Error");
                }
                var user = uManager.FindById(userId);
                if(user == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        //Get:
        public ActionResult Profile(string userId, string roleName)
        {
            if(userId == null || roleName == null )
            {
                return View("Error");
            }
            var user = uManager.FindById(userId);
            if(userId == null)
            {
                return View("Error");
            }

            //identity user self with ViewData, dont need to fill Model
            ViewData["Account"] = user;
            ViewBag.Role = roleName;
            return View();
        }
    }
}