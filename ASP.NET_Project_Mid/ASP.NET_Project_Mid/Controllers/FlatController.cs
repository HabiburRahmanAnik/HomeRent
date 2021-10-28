using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project_Mid.Repo;


namespace ASP.NET_Project_Mid.Controllers
{
    public class FlatController : Controller
    {
        // GET: Flat
        public ActionResult AddFlat()
        {
            return View();
        }
        public ActionResult ViewFlats()
        {
            var f = FlatRepository.GetAll();
            return View(f);
        }
    }
}