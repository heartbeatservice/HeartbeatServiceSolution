using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBS.Data.Entities;
using HBS.Data.Abstract;
using HBS.Data.Concrete;
using HBS.Entities;
using System.Web;

namespace HBS.WebApi.Controllers
{
    public class ProfessionalAppointmentsListController : ApiController
    {
        IAppointmentRepository repository;
        ProfessionalAppointmentsListController(IAppointmentRepository repo)
        {
            repository = repo;
        }



        public IList<Appointment> GetProfessionalAppointment(int professionalId,DateTime appointmentDate)
        {
            return repository.GetProfessionalAppointments(professionalId,appointmentDate);

        }
     
    }
}
