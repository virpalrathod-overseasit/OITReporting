using OITReporting.Manager.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Web.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployee()
        {
            OITdataDataContext db = new OITdataDataContext(@"Data Source=PATEL-PC;Initial Catalog=dbOITReporting;Integrated Security=True");
            var employees = db.userMasters.OrderBy(emp => emp.firstName).ToList();
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult addUser()
        {
            return View();
        }
    }
}