using OITReporting.Manager.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtEmail, string txtPassword)
        {
            OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True");
            var loginresult = db.userMasters.Where(a => a.emailID == txtEmail && a.password == txtPassword).FirstOrDefault();
            if (loginresult!= null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.message = "Invalid Username and Password";
                return View("Login");
            }            
            //return Json("Invalid Data",JsonRequestBehavior.AllowGet);
        }
    }
}