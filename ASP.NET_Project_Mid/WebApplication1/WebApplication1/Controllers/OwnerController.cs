using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.EF;

namespace WebApplication1.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        public ActionResult OwnerIndex()
        {
            return View();
        }

        //
        public ActionResult FlatList()
        {
            HomeRentEntities1 db = new HomeRentEntities1();
            var flat = from fl in db.Flats
                       select fl;

            return View(flat.ToList());
        }

        //
        [HttpGet]
        public ActionResult AddFlat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFlat(Flat flat)
        {
            if (ModelState.IsValid)
            {
                HomeRentEntities1 db = new HomeRentEntities1();
                db.Flats.Add(flat);
                db.SaveChanges();
                return RedirectToAction("FlatList");
            }
            return View();
        }
        //
        public ActionResult CustomerDetails()
        {
            HomeRentEntities1 db = new HomeRentEntities1();
            var cud = from c in db.Users
                      select c;

            return View(cud);
        }











        public ActionResult Delete(int id)
        {
            using (HomeRentEntities1 db = new HomeRentEntities1())
            {
                User us = (from u in db.Users
                           where u.UserId == id
                           select u).FirstOrDefault();
                db.Users.Remove(us);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (HomeRentEntities1 db = new HomeRentEntities1())
            {
                User us = (from u in db.Users
                           where u.UserId == id
                           select u).FirstOrDefault();
                return View(us);
            }
        }

        [HttpPost]
        public ActionResult Edit(User u, int id)
        {
            using (HomeRentEntities1 db = new HomeRentEntities1())
            {
                User entity = (from ur in db.Users
                               where ur.UserId == u.UserId
                               select ur).FirstOrDefault();
                db.Entry(entity).CurrentValues.SetValues(u);
                db.SaveChanges();

                return RedirectToAction("UserList");
            }

        }
    }
}