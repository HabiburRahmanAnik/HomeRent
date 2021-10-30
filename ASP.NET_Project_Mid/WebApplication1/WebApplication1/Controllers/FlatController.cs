using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    [Authorize]
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