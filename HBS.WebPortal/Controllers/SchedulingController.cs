using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBS.WebPortal.Controllers
{
    public class SchedulingController : Controller
    {
        public ActionResult Index()
        {
            
            
            return View();
        }

        public ActionResult Customer()
        {

            ViewBag.companyid = getCompanyId();
            ViewBag.userid = getUserId();
            return View();
        }

        public ActionResult Daily()
        {
            return View();
        }


        public ActionResult Weekly()
        {
            return View();
        }

        int getCompanyId()
        {
            int companyid=0;
            if (Session["user"] != null)
                companyid = ((HBS.WebPortal.Models.User)Session["user"]).companyid;
            return companyid;
        }

        int getUserId()
        {
            int userid = 0;
            if(Session["user"]!=null)
                userid = ((HBS.WebPortal.Models.User)Session["user"]).userid;
            return userid;
        }
    }
}
