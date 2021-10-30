using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.EF;
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
  [HttpPost]
        public ActionResult Login(User u )
        {
            var user = UserRepository.Authenticate(u.Email, u.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email,true);
                return RedirectToAction("Login", "Flat");

            }
            return RedirectToAction("Login");
        }
    }
}