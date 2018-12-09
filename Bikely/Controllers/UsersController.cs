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
        public ApplicationDbContext context;

        public UsersController()
        {
            logCounter = 0;
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                logCounter++;
                ViewBag.Count = logCounter.ToString();

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
                                     showHiddenLinks = true
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
                                     showHiddenLinks = false
                                 });
                    return View(users);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}