using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult UserList()
        {
            HomeRentEntities db = new HomeRentEntities();
            var user = from u in db.Users
                       select u;

            return View(user.ToList());
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                HomeRentEntities db = new HomeRentEntities();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using(HomeRentEntities db = new HomeRentEntities())
            {
                var u = (from us in db.Users
                         where us.UserId == id
                         select us).First();
                return View(u);
            }
        }

        public ActionResult Delete(int id)
        {
           using (HomeRentEntities db = new HomeRentEntities())
            {
                User us = (from u in db.Users
                          where u.UserId == id
                          select u).FirstOrDefault();
                db.Users.Remove(us);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
        }

    }
}