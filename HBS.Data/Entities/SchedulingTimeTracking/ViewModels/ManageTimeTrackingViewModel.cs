using HBS.Data.Entities.SchedulingTimeTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBS.Data.Entities.SchedulingTimeTracking.ViewModels
{
    public class ManageTimeTrackingViewModel
    {
        public UserList UserList { get; set; }

        public DailyTimeTrackViewModel DailyTimeTrack { get; set; }
        public ManageTimeTrackingViewModel(DailyTimeTrackViewModel dailyTimeTrack, UserList userList)
        {
            DailyTimeTrack = dailyTimeTrack;
            UserList = userList;
        }

    }
}
