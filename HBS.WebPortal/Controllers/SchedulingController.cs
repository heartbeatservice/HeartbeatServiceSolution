using HBS.Data.Entities.SchedulingTimeTracking.Models;
using HBS.Data.Entities.SchedulingTimeTracking.ViewModels;
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
        public ActionResult WorkflowDetail()
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

        public ActionResult DailyTimeTrack()
        {
            try
            { 
                return View(HBS.Data.Entities.SchedulingTimeTracking.Models.TimeTrackingManager.GetCurrentDayClockInOutTime(((HBS.WebPortal.Models.User)Session["user"]).UserName)); 
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home", new { id = ex.Message });
            }
        }

        public PartialViewResult DailyTimeTrackPartial()
        {
            return PartialView("_DailyTimeTrack", HBS.Data.Entities.SchedulingTimeTracking.Models.TimeTrackingManager.GetCurrentDayClockInOutTime(((HBS.WebPortal.Models.User)Session["user"]).UserName));
        }

        public ActionResult Track()
        {
            TimeTrackingManager.TrackClockInOutTime(((HBS.WebPortal.Models.User)Session["user"]).userid, ((HBS.WebPortal.Models.User)Session["user"]).UserName);
            return View("DailyTimeTrack", TimeTrackingManager.GetCurrentDayClockInOutTime(((HBS.WebPortal.Models.User)Session["user"]).UserName));
        }

        public ActionResult WeeklyTimeTrack(string id)
        {
            return View("WeeklyTimeTrack", TimeTrackingManager.GetCurrentWeekClockInOutTime(id ?? ((HBS.WebPortal.Models.User)Session["user"]).UserName));
        }

        public ActionResult WeeklyByDate(string id, string startDate, FormCollection collection)
        {
            DateTime weekStartDate;
            if (DateTime.TryParse(collection["SelectedValue"], out weekStartDate))
            {
                return PartialView("_WeeklyTimeTrack",
                                   TimeTrackingManager.GetClockInOutTime(id ?? ((HBS.WebPortal.Models.User)Session["user"]).UserName, weekStartDate,
                                                                      weekStartDate.AddDays(6)));
            }
            return PartialView("WeeklyTimeTrack", new WeeklyTimeTrackWeekListViewModel());
        }

        public PartialViewResult TimeTrackingReport(FormCollection collection)
        {
            DateTime startDate;
            DateTime endDate;
            if (DateTime.TryParse(collection["txtStartDate"], out startDate) && DateTime.TryParse(collection["txtEndDate"], out endDate))
            {
                var model = TimeTrackingManager.GetUserTimeTrackHistoryForSpecifiedPeriod(getCompanyId(), Convert.ToInt32(collection["UserList.SelectedValue"]), startDate, endDate);
                return PartialView("TimeTrackingReport", model);
            }
            else
                return PartialView("TimeTrackingReport", new TimeTrackReportViewModel(new CustomTimeTrack(), new UserList(string.Empty, getCompanyId())));
        }

        public void ExportUserHistory(FormCollection collection)
        {
            string userName = collection["uname"];
            DateTime startDate;
            DateTime endDate;
            if (DateTime.TryParse(collection["startDate"], out startDate) && DateTime.TryParse(collection["endDate"], out endDate))
            {
                var model = TimeTrackingManager.GetUserTimeTrackHistoryForSpecifiedPeriod(userName, startDate, endDate);
                //return PartialView("_GetUserHistory", model);
                IExportPage export = new ExportPage();
                var reportName = model.EmployeeName.Replace(" ", "_") + "_" + model.CustomStartEndDateDisplay.Replace(" ", "-");
                export.ExportExcel(HBS.Data.Entities.SchedulingTimeTracking.Infrastructure.ExcelReportHelper.GetExcelString(model, reportName), reportName + ".xls");
            }


            //return PartialView("_GetUserHistory", new CustomTimeTrack());
        }

        public ActionResult ManageTimeTracking(FormCollection collection)
        {
            string userName = collection["UserList.SelectedValue"];
            DateTime startDate;
            if (DateTime.TryParse(collection["txtStartDate"], out startDate))
            {
                var endDate = startDate;
                var model = TimeTrackingManager.GetDailyClockInOutTimeByDate(Convert.ToInt32(userName), startDate, endDate);

                ViewBag.UserName = userName;
                //ViewBag.UserFullName = collection["user"];
                return View("ManageTimeTracking", new ManageTimeTrackingViewModel(new DailyTimeTrackViewModel(model, Convert.ToInt32(userName)), new UserList(string.Empty, getCompanyId())));
            }
            else
                return View("ManageTimeTracking", new ManageTimeTrackingViewModel(new DailyTimeTrackViewModel() { UserFullName = "", UserName = "" }, new UserList(string.Empty, getCompanyId())));
        }

        public ActionResult CreateTimeTrack(FormCollection collection)
        {
            UserTimeTrackHistoryMapped utth = new UserTimeTrackHistoryMapped(getCompanyId());
            //var userList = MembershipUserExtended.GetFullNameUserNameList();
            string userName = collection["UserName"];
            utth.UserName = userName;

            DateTime clockInDt;
            DateTime clockOutDt;
            if (DateTime.TryParse(collection["ClockInTime"], out clockInDt) && DateTime.TryParse(collection["ClockOutTime"], out clockOutDt))
            {
                if (clockOutDt.TimeOfDay.CompareTo(clockInDt.TimeOfDay) != -1) // if clock out time is earlier than clock in time than error
                {
                    utth.ClockInTime = string.Format("{0:t}", clockInDt);
                    utth.ClockOutTime = string.Format("{0:t}", clockOutDt);
                    utth.UserId = Convert.ToInt32(userName);
                    //utth.UserId = ((HBS.WebPortal.Models.User)Session["user"]).userid;
                    utth.CreatedBy = ((HBS.WebPortal.Models.User)Session["user"]).UserName;
                    utth.CreatedDate = HBS.Data.Entities.SchedulingTimeTracking.Infrastructure.WebHelpers.GetCurrentDateTimeByTimeZoneId(System.Configuration.ConfigurationManager.AppSettings["UserTimeZoneId"]);
                    utth.IsDeleted = false;
                    var tth = utth.Get(utth.Save(),getCompanyId());
                    tth.UserName = userName;
                    ViewBag.Message = "Record inserted successfully.";
                    return View(tth);
                }
                else
                {
                    ViewBag.Message = "Clock Out time can not be earlier than Clock In time.";
                    return View(utth);
                }
            }
            else
            {
                ViewBag.Message = "Not a valid Clock In/Out time, please make sure time is in correct format.";
                return View(utth);
            }
            //ViewBag.Message = "Error inserting record.";
            //return View(new UserTimeTrackHistoryMapped());
        }
        public ActionResult UpdateClockInOutTime(int timeTrackId, string stampDate, string selectedUser, string clockInTime, string clockOutTime)
        {
            var userTimeTrackRecord = TimeTrackingManager.UpdateClockInOutTime(timeTrackId, stampDate, selectedUser, clockInTime, clockOutTime, ((HBS.WebPortal.Models.User)Session["user"]).UserName);
            return Json(userTimeTrackRecord);
        }
        public JsonResult DeleteTimeTrackRecord(int timeTrackId)
        {
            var userTimeTrackRecord = TimeTrackingManager.DeleteTimeTrackRecord(timeTrackId, ((HBS.WebPortal.Models.User)Session["user"]).UserName);
            return Json(userTimeTrackRecord, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult TimeTrackingReport()
        //{
        //    return View(new UserList(string.Empty,getCompanyId()));
        //    //return View();
        //}
    }
}
