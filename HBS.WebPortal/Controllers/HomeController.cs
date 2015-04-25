using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



using HBS.Entities;
using HBS.WebPortal.Models;
namespace HBS.WebPortal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string id)
        {
            //RapidRedis<Customer> r = new RapidRedis<Customer>();
            //Customer c = new Customer();
            //c.CustomerId = 1;
            //c.FirstName = "Umais";
            //c.LastName = "Siddiqui";
            //c.MiddleInitial = "N";
            //c.IsActive = true;
            //c.HomePhone = "xxxxxx";
            //c.DateOfBirth = "06/15/1980";
            //r.InsertObject(c,"customer:1:App:Website");
            
            if(id!=null)
                ViewBag.error = id;
            

            //ViewBag.Test ="test";
             

            
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
        public ActionResult SignUp()
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

        public ActionResult Goals()
        {

            return View();
        }

        public ActionResult CourseOutline()
        {

            return View();
        }

      
        [HttpPost]
        public ActionResult Index(User u)
        {
            string username = u.UserName;
            string pwd = u.Password;
            string view = "Index";

            u.ValidatePassword();
            if (u.userid > 0)
            {
                Session["user"] = u;
                view = "Login";
                Session["app"] = "Scheduling";
            }
            else
                ViewBag.error = "Invalid User Name or password";
            return RedirectToAction(view);
        }

        public ActionResult Login()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", new { id = "You cannot access page without Logging In" });
            }
            else
            {
                if (((HBS.WebPortal.Models.User)Session["user"]).RoleId == 0)
                {
                    return RedirectToAction("Index", new { id = "You currently do not have a role assigned please contact system Administrator" });
                }
            }
            return RedirectToAction("Index","Scheduling");
        }
        
        public ActionResult LogOut()
        {
            Session.Abandon();
            
            return RedirectToAction("Index", new { id ="Successfully Logged Out" });
        }

 
    }
}
