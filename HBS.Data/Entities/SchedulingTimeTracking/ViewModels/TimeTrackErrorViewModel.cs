﻿using HBS.Data.Entities.SchedulingTimeTracking.Models;

namespace HBS.Data.Entities.SchedulingTimeTracking.ViewModels
{
    public class TimeTrackErrorViewModel
    {
        public TimeTrack TimeTrack { get; set; }
        public string ErrorMessage { get; set; }

        public TimeTrackErrorViewModel()
        {
        }

        public TimeTrackErrorViewModel(TimeTrack timeTrack,string errorMessage)
        {
            TimeTrack = timeTrack;
            ErrorMessage = errorMessage;
        }
    }
}
