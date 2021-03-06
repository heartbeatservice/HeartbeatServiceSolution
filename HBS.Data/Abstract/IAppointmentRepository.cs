﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities;

namespace HBS.Data.Abstract
{
    public interface IAppointmentRepository
    {


      int AddAppointment(Appointment appointment);

       bool UpdateAppointment(Appointment appointment);


        List<Appointment> GetProfessionalAppointments(int professionalId, DateTime appointmentDate);


        List<Appointment> GetCustomerAppointments(int companyid, int? customerId, int professionalId, DateTime startDate, Nullable<DateTime> endDate);

        List<Appointment> GetCustomerAppointments(int companyid, bool dashboardFlag);


    }
}
