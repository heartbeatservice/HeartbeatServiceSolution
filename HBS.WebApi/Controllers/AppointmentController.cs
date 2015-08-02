using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBS.Data.Abstract;
using HBS.Data.Concrete;
using HBS.Entities;
using System.Web;

namespace HBS.WebApi.Controllers
{
    public class AppointmentController : ApiController
    {

        IAppointmentRepository repository;
        public AppointmentController(IAppointmentRepository repo)
        {
            repository = repo;
        }

        public int PostAddAppointment([FromBody]Appointment appointment)
        {
            return repository.AddAppointment(appointment);
        }

        public IList<Appointment> GetCustomerAppointment(int customerId)
        {
            //return repository.GetCustomerAppointments(customerId);
            return null;
        }

        public IList<Appointment> GetCustomerAppointment(int companyId, int customerId, int professionalId, DateTime startdate, DateTime enddate)
        {
            return repository.GetCustomerAppointments(companyId, customerId, professionalId, startdate, enddate);
        }

        public IList<Appointment> GetCustomerAppointment(int companyId, int professionalId, DateTime startdate)
        {
            return repository.GetCustomerAppointments(companyId, null, professionalId, startdate, null);
        }

        public IList<Appointment> GetCustomerAppointment(int companyId, string dashboardFlag)
        {
            return repository.GetCustomerAppointments(companyId, true);
        }

        public IList<Appointment> GetCustomerAppointment(int companyId, int customerId, int professionalId, DateTime startdate)
        {
            return repository.GetCustomerAppointments(companyId, customerId, professionalId, startdate, null);
        }
        public IList<Appointment> GetCustomerAppointment(int companyId, int professionalId, DateTime startdate, DateTime enddate)
        {
            return repository.GetCustomerAppointments(companyId, null, professionalId, startdate, enddate);
        }
        public bool PutUpdateAppointment([FromBody]Appointment appointment)
        {
            return repository.UpdateAppointment(appointment);
        }
        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            return resp;
        }
    }
}
