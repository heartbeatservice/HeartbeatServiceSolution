﻿using System.Collections.Generic;
using System.Web.Mvc;
using HBS.Data.Entities.SchedulingTimeTracking.Models;

namespace HBS.Data.Entities.SchedulingTimeTracking.ViewModels
{
    public class WeeklyTimeTrackWeekListViewModel
    {
        public WeeklyTimeTrackWeekListViewModel()
        {
            WeeklyTimeTrack=new WeeklyTimeTrack();
            WeekList = new List<SelectListItem>();
        }

        public WeeklyTimeTrackWeekListViewModel(WeeklyTimeTrack weeklyTimeTrack, IEnumerable<SelectListItem> weekList)
        {
            WeeklyTimeTrack = weeklyTimeTrack;
            WeekList = weekList;
        }

        public WeeklyTimeTrack WeeklyTimeTrack { get; set; }
        public string SelectedValue { get; set; }
        public IEnumerable<SelectListItem> WeekList { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        //public int NumberOfWeeks { get; set; }
    }
}
