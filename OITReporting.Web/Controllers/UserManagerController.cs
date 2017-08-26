using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OITReporting.Manager.DbModel;
namespace OITReporting.Web.Controllers
{
    public class UserManagerController : Controller
    {
        userDB user = new userDB();
        
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(user.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(userMaster ur)
        {
            return Json(user.Add(ur), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var userd = user.ListAll().Find(x => x.userId.Equals(ID));
            return Json(userd, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(userMaster ur)
        {
            return Json(user.Update(ur), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(user.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}