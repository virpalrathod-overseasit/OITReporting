using OITReporting.Manager;
using OITReporting.Manager.DbModel;
using System;
using System.Linq;
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
        [HttpPost]
        public ActionResult addUser(userReg ur)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Invalid Request";
                return View(ur);
            }
            OITdataDataContext db = new OITdataDataContext(@"Data Source=PATEL-PC;Initial Catalog=dbOITReporting;Integrated Security=True");
                userMaster um = new userMaster();
                um.firstName = ur.firstName;
                um.lastName = ur.lastName;
                um.dob = ur.dob;
                um.gender = ur.gender;
                um.address = ur.address;
                um.city = ur.city;
                um.state = ur.state;
                um.countryId = ur.country;
                um.contactNo = ur.contactNo;
                um.emailID = ur.emailID;
                um.password = ur.password;
                db.userMasters.InsertOnSubmit(um);
                db.SubmitChanges();
                ViewBag.success = "Successfully Added New User";
            return View();
        }
    }
}