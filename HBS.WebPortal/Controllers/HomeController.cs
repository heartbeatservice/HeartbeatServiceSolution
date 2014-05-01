using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Redis;
using System.Text;
using Newtonsoft.Json;
using HBS.Entities;
namespace HBS.WebPortal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //using (IRedisNativeClient client = new RedisClient("162.243.79.25",6379,"Karachi@8681",0))
            //{
            //    var test=Encoding.UTF8.GetString(client.Get("test"));
            //    ViewBag.Test = test;

            //}

            Customer c = new Customer();
            c.CustomerId = 1;
            c.FirstName="Umais";
            c.LastName = "Siddiqui";
            c.MiddleInitial = "A";
            c.IsActive = true;
            c.HomePhone = "917-754-6930";
            c.DateOfBirth = "06/15/1980";

            //ViewBag.Test ="test";
             Byte[] blob=Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(c));

            //string key = "1:2";
            //using (IRedisNativeClient client = new RedisClient("162.243.79.25", 6379, "Karachi@8681", 0))
            //{
            //    client.Set(key,blob);
                

            //}
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

        [HttpPost]
        public ActionResult Login()
        {
            string username = Request.Form["user"].ToString();
            string pwd = Request.Form["pass"].ToString();
            Session["user"] = username.ToString();
            return View("Team");
        }

    }
}
