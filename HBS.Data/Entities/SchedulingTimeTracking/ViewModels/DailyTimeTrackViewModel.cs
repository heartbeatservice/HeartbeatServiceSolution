using HBS.Data.Entities.SchedulingTimeTracking.EF;
using HBS.Data.Entities.SchedulingTimeTracking.Models;
using System.Linq;

namespace HBS.Data.Entities.SchedulingTimeTracking.ViewModels
{
    public class DailyTimeTrackViewModel
    {
        public DailyTimeTrackViewModel()
        {
            DailyTimeTrack= new DailyTimeTrack();
            UserFullName = string.Empty;
        }

        public DailyTimeTrackViewModel(DailyTimeTrack dailyTimeTrack, int userId)
        {
            using (var dbContext = new SchTimeTrackingEntities())
            {
                var currentUser =
                            dbContext.UserProfiles.FirstOrDefault(c => c.UserId.Equals(userId));
                DailyTimeTrack = dailyTimeTrack;
                UserFullName = currentUser.FirstName + " " + currentUser.LastName;
                UserName = currentUser.UserName; 
            }
        }

        public DailyTimeTrack DailyTimeTrack { get; set; }
        public string UserFullName { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }        
    }
}
