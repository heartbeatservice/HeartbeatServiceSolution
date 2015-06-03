using HBS.Data.Entities.SchedulingTimeTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBS.Data.Entities.SchedulingTimeTracking.ViewModels
{
    public class TimeTrackReportViewModel
    {
        public TimeTrackReportViewModel(CustomTimeTrack customTimeTrack, UserList userList)
        {
            CustomTimeTrack = customTimeTrack;
            UserList = userList;
        }
        public CustomTimeTrack CustomTimeTrack { get; set; }
        public UserList UserList { get; set; }
    }
}
