using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Web.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
    }
}