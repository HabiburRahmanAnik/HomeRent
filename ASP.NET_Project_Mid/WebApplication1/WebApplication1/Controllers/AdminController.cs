using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Auth;
using WebApplication1.Models;
using WebApplication1.Models.Classes;

namespace WebApplication1.Controllers
{
    [Authorize]
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

        public ActionResult ViewDetails(int id)
        {
            HomeRentEntities db = new HomeRentEntities();

            var us = (from u in db.Users
                      where u.UserId == id
                      select u).First();
            return View(us);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (HomeRentEntities db = new HomeRentEntities())
            {
                User us = (from u in db.Users
                           where u.UserId == id
                           select u).FirstOrDefault();
                return View(us);
            }
        }

        [HttpPost]
        public ActionResult Edit(User u)
        {

            string connString = @"Server=DESKTOP-N5QEM8V\SQLEXPRESS;Database=HomeRent;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            string query = string.Format("update Users set Username='{0}' Email='{1}' active='{2}' Type='{3}' where UserId='{4}'",u.Username,u.Email,u.active,u.Type,u.UserId);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("UserList");

        }

        public ActionResult Block(int id)
        {
            string connString = @"Server=DESKTOP-N5QEM8V\SQLEXPRESS;Database=HomeRent;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connString);
            string query = string.Format("update Users set active='{0}' where UserId='{1}'", 0, id);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("UserList");
        }

        // Flat 
        public ActionResult HouseList()
        {
            HomeRentEntities db = new HomeRentEntities();
            var flat= db.Flats.ToList();
            return View(flat);
        }

        public ActionResult FlatDetails(int id)
        {
            using(HomeRentEntities db = new HomeRentEntities())
            {
                var flat = (from f in db.Flats
                            where f.FlatId == id
                            select f).First();
                return View(flat);
            }
        }

        public ActionResult FlatDelete(int id)
        {
            using(HomeRentEntities db = new HomeRentEntities())
            {
                var flat = (from f in db.Flats
                            where f.FlatId == id
                            select f).First();
                db.Flats.Remove(flat);
                db.SaveChanges();

                return RedirectToAction("HouseList");
            }
        }

        [HttpGet]
        public ActionResult FlatEdit(int id)
        {
            using (HomeRentEntities db = new HomeRentEntities())
            {
                var flat = (from f in db.Flats
                            where f.FlatId == id
                            select f).First();

                return View(flat);
            }
        }

        [HttpPost]
        public ActionResult FlatEdit(Flat f,int id)
        {
            using (HomeRentEntities db = new HomeRentEntities())
            {
                var flat = (from ft in db.Flats
                            where ft.FlatId == id
                            select ft).FirstOrDefault();

                flat.FlatSize = f.FlatSize;
                flat.Location = f.Location;
                flat.Rent = f.Rent;
                flat.RoomDetails = f.RoomDetails;

                db.SaveChanges();

                return RedirectToAction("HouseList");
            }
        }

    }
}