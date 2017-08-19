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

            OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True");
            var employees = db.userMasters.OrderBy(emp => emp.firstName).ToList();
            return View(employees);
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
            OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True");
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
        [HttpGet]
        public ActionResult editUser(int id)
        {
            using (OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
            {
                var v = db.userMasters.Where(a => a.userId == id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult editUser(userMaster ur)
        {

            if (ModelState.IsValid)
            {
                using (OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
                {
                    if (ur.userId > 0)
                    {
                        var v = db.userMasters.Where(a => a.userId == ur.userId).FirstOrDefault();
                        if (v != null)
                        {

                            v.firstName = ur.firstName;
                            v.lastName = ur.lastName;
                            v.dob = ur.dob;
                            v.gender = ur.gender;
                            v.address = ur.address;
                            v.city = ur.city;
                            v.state = ur.state;
                            v.countryId = ur.countryId;
                            v.contactNo = ur.contactNo;
                            v.emailID = ur.emailID;


                            db.SubmitChanges();
                        }
                    }
                    else
                    {


                    }

                    db.SubmitChanges();

                }
            }
            return View();
        }



        public ActionResult deleteUser(int id)
        {
            using (OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
            {
                var v = db.userMasters.Where(a => a.userId == id).FirstOrDefault();
                if (v != null)
                {
                    db.userMasters.DeleteOnSubmit(v);
                    db.SubmitChanges();
                    return View("Index");
                }
                else
                {
                    return HttpNotFound();
                }

            }
        }
        /*
    [HttpPost]
    public ActionResult delteUser(userMaster ur)
    {


       using (OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
         {
             userMaster v = db.userMasters.Where(x => x.userId == ur.userId).Single<userMaster>();
             db.userMasters.DeleteOnSubmit(ur);
             db.SubmitChanges();
             return RedirectToAction("Index");
         }

        using (OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
        {
            var v = db.userMasters.Where(a => a.userId == id).FirstOrDefault();
            if (v != null)
            {

                db.userMasters.DeleteOnSubmit(v);
                db.SubmitChanges();
                RedirectToAction("Index");
            }
            else
            {
                return View("deleteUser");
            }

        */
       
    }
}

