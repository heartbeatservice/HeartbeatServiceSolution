using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HBS.WebPortal.Controllers
{
    public class SchedulingController : Controller
    {
        //public ActionResult Index()
        //{
        //    ActionResult action = Redirect();
        //    if (action == null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return action;
        //    }
        //}
        public ActionResult Appointment()
        {
            if (Session["user"] == null)
            {

                return RedirectToAction("Index", "Home", new { id = "You cannot access page without Logging In" });
            }
            ViewBag.companyid = getCompanyId();
            ViewBag.userid = getUserId();
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }
        public ActionResult Customer()
        {
            if (Session["user"] == null)
            {

                return RedirectToAction("Index", "Home", new { id = "You cannot access page without Logging In" });
            }
            ViewBag.companyid = getCompanyId();
            ViewBag.userid = getUserId();
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        public ActionResult Daily()
        {
            if (Request.QueryString["CustomerId"] != null)
                ViewBag.CustomerId = Request.QueryString["CustomerId"].ToString();
            else
                ViewBag.CustomerId = "0";
            if (Request.QueryString["ProfessionalId"] != null)
                ViewBag.ProfessionalId = Request.QueryString["ProfessionalId"].ToString();
            else
                ViewBag.ProfessionalId = "0";
            ViewBag.CurrentDate = DateTime.Now.ToShortDateString();
            ViewBag.companyid = getCompanyId();
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }


        public ActionResult Weekly()
        {
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        int getCompanyId()
        {
            int companyid = 0;
            if (Session["user"] != null)
                companyid = ((HBS.WebPortal.Models.User)Session["user"]).companyid;
            return companyid;
        }

        int getUserId()
        {
            int userid = 0;
            if (Session["user"] != null)
                userid = ((HBS.WebPortal.Models.User)Session["user"]).userid;
            return userid;
        }

        public ActionResult Professional()
        {
            ActionResult action = Redirect();

            ViewBag.companyid = getCompanyId();
            ViewBag.userid = getUserId();

            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }


        public ActionResult Insurance()
        {
            ActionResult action = Redirect();
            ViewBag.companyid = getCompanyId();
            ViewBag.userid = getUserId();

            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        public ActionResult Contact()
        {
            ActionResult action = Redirect();

            ViewBag.companyid = getCompanyId();
            ViewBag.userid = getUserId();

            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        public ActionResult Project()
        {
            ActionResult action = Redirect();

            ViewBag.companyid = getCompanyId();
            ViewBag.userid = getUserId();

            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        public ActionResult Workflow()
        {
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        public ActionResult WorkflowAdmin()
        {
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        public ActionResult Company()
        {
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        public ActionResult Module()
        {
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }
        public ActionResult Index(int? companyId)
        {
            if (companyId != null)
            {
                HBS.WebPortal.Models.User user = Session["user"] as HBS.WebPortal.Models.User;
                user.companyid = companyId.Value;
                Session["user"] = user;
            } ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }
        public ActionResult User()
        {
            ActionResult action = Redirect();
            if (action == null)
            {
                return View();
            }
            else
            {
                return action;
            }
        }

        private ActionResult Redirect()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home", new { id = "You cannot access page without Logging In" });
            }
            else
            {
                if (((HBS.WebPortal.Models.User)Session["user"]).RoleId == 0)
                {
                    return RedirectToAction("Index", "Home", new { id = "You currently do not have a role assigned please contact system Administrator" });
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
