using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OITReporting.Manager.DbModel;
namespace OITReporting.Web.Controllers
{
    public class ClientManagerController : Controller
    {
        clientDB client =new  clientDB();
        OITdataDataContext db = new OITdataDataContext(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True");

        public ActionResult Index()
        {
            //var profileData = this.Session["UserProfile"] as userMaster;
            //var userref = db.userMasters.Where(a => a.userId == profileData.userId).FirstOrDefault();
            ViewBag.userid =1031;
            var domainlist = db.domainMasters.ToList();
            SelectList list = new SelectList(domainlist, "domainId", "domainName");
            ViewData["domain"] = list;
            return View();
        }
        public JsonResult List()
        {
            return Json(client.ListAll(), JsonRequestBehavior.AllowGet);
        }
        

    }
}