using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HBS.Data.Entities.SchedulingTimeTracking.EF;
using HBS.Data.Entities.SchedulingTimeTracking.Models;

namespace HBS.Data.Entities.SchedulingTimeTracking.Models
{
    public class UserTimeTrackHistoryMapped
    {
        public int TimeTrackId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ClockInTime { get; set; }
        public string ClockOutTime { get; set; }
        public DateTime StampDate { get; set; }
        public string UserIp { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SelectListItem> ClockInTimeList { get; set; }
        public IEnumerable<SelectListItem> ClockOutTimeList { get; set; }

        public UserTimeTrackHistoryMapped(int companyId)
        {
            UserName = string.Empty;
            ClockInTime = string.Empty;
            ClockOutTime = string.Empty;
            IsDeleted = false;
            StampDate = DateTime.Now.Date; using (var dbContext = new SchTimeTrackingEntities())
            {
                var ulist = dbContext.UserProfiles.Where(c => c.CompanyId.Equals(companyId));

                List<HBS.Entities.UserProfile> userprofile = new List<HBS.Entities.UserProfile>();
                foreach (UserProfile item in ulist)
                {
                    userprofile.Add(new HBS.Entities.UserProfile(item.CompanyId, item.UserName, item.Password, item.FirstName, item.LastName, item.Email, item.UserId, (item.RoleId.HasValue ? item.RoleId.Value : 0)));
                }

                if (!string.IsNullOrEmpty(UserName))
                    Users = new SelectList(userprofile, "UserId", "UserName", UserName);
                else
                    Users = new SelectList(userprofile, "UserId", "UserName");
            }
            ClockInTimeList = new SelectList(GetTimeListOfADay(15), ClockInTime);
            ClockOutTimeList = new SelectList(GetTimeListOfADay(15), ClockOutTime);
        }

        List<string> GetTimeListOfADay(int interval)
        {
            var sbTimeList = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                var index = (60 / interval);
                var intervalIncrement = 0;

                for (int j = 0; j < index; j++)
                {
                    sbTimeList.Add(string.Format("{0}:{1}:00", i < 10 ? "0" + i.ToString() : i.ToString(), intervalIncrement == 0 ? "0" + intervalIncrement.ToString() : intervalIncrement.ToString()));

                    intervalIncrement += interval;
                }
            }

            return sbTimeList.Where(c => !c.Equals("23:60")).ToList();
        }

        public int Save()
        {
            using (var dbContext = new SchTimeTrackingEntities())
            {
                UserName = dbContext.UserProfiles.FirstOrDefault(c => c.UserId.Equals(UserId)).UserName;
                var utth = new UserTimeTrackHistory
                    {
                        UserId = UserId,
                        UserName = UserName,
                        ClockInTime = ClockInTime,
                        ClockOutTime = ClockOutTime,
                        StampDate = StampDate,
                        UserIP = UserIp,
                        IsDeleted = IsDeleted,
                        CreatedBy = CreatedBy,
                        CreatedDate = CreatedDate
                    };
                dbContext.UserTimeTrackHistories.Add(utth);
                dbContext.SaveChanges();
                return utth.TimeTrackId;
            }
        }
        public UserTimeTrackHistoryMapped Get(int timeTrackId, int companyId)
        {
            using (var dbContext = new SchTimeTrackingEntities())
            {
                var userTimeTrackRecord =
                    dbContext.UserTimeTrackHistories.FirstOrDefault(c => c.TimeTrackId == timeTrackId);
                if (userTimeTrackRecord != null)
                {
                    var timeTrackMappedRecord = new UserTimeTrackHistoryMapped(companyId)
                        {
                            TimeTrackId = userTimeTrackRecord.TimeTrackId,
                            UserName = userTimeTrackRecord.UserName,
                            UserId = userTimeTrackRecord.UserId,
                            ClockInTime = userTimeTrackRecord.ClockInTime,
                            ClockOutTime = userTimeTrackRecord.ClockOutTime,
                            StampDate = userTimeTrackRecord.StampDate,
                            IsDeleted = userTimeTrackRecord.IsDeleted,
                            CreatedBy = userTimeTrackRecord.CreatedBy,
                            CreatedDate = userTimeTrackRecord.CreatedDate
                        };
                    return timeTrackMappedRecord;
                }
                return new UserTimeTrackHistoryMapped(companyId);
            }
        }
    }
}
