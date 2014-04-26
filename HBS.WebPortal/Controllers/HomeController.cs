using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Redis;
using System.Text;
namespace HBS.WebPortal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (IRedisNativeClient client = new RedisClient("162.243.79.25",6379,"Karachi@8681",0))
            {
                var test=Encoding.UTF8.GetString(client.Get("test"));
                ViewBag.Test = test;

            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

    }
}
