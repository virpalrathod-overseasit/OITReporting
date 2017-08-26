using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OITReporting.Manager.DbModel;
namespace OITReporting.Web.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]

        OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True");

        public ActionResult Dashboard()
        {
            userMaster u = new userMaster();
            clientMaster c = new clientMaster();
            domainMaster d = new domainMaster();
            ViewBag.usertotal = db.userMasters.Count();
            ViewBag.domaintotal = db.domainMasters.Count();
            var count = db.clientMasters.Select(p => p.companyName).Distinct().Count();
            ViewBag.companyNametotal = count;
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