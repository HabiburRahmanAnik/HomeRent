using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.EF;
//using WebApplication1.Models.VM;
using WebApplication1.Models;

using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        
        public ActionResult Registration()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Registration(User u)
        {
            HomeRentEntities db = new HomeRentEntities();
            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpPost]
          public ActionResult Login(User u )
          {
              var user = UserRepository.Authenticate(u.Email, u.Password);
              if (user != null)
              {
                  FormsAuthentication.SetAuthCookie(user.Email,true);

                if (user.Type==1)
                {
                    return RedirectToAction("AdminDashboard", "Admin");

                }
                else
                    ViewBag.Message = "Invalid User Email or pass";
            }
            return RedirectToAction("Login", "User");


        }




    }
}