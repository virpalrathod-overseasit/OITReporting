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
            /*if (txtEmail == "admin" && txtPassword == "admin")
            {
                
       
                if (txtEmail != null && txtPassword != null)
                {
                    ViewBag.user = "user";
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ViewBag.message = "Invalid Username and Password";
                    return View("Login");
                }
            }
            else
            {*/
                OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True");
                var loginresult = db.userMasters.Where(a => a.emailID == txtEmail && a.password == txtPassword).FirstOrDefault();
                if (loginresult != null)
                {
                    Session["UserProfile"] = loginresult;
                    ViewBag.user = "user";
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ViewBag.message = "Invalid Username and Password";
                    return View("Login");
                }
            //}
            //return Json("Invalid Data",JsonRequestBehavior.AllowGet);
        }
    }
}