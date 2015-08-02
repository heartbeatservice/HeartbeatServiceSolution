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
using HBS.WebApi.Models;

namespace HBS.WebApi.Controllers
{
    public class DashboardController : ApiController
    {
        ICommonRepository repository;

        public DashboardController(ICommonRepository repo)
        {
            repository = repo;
        }

        public Alert GetAlerts(int companyId, int userId)
        {
            return repository.GetAlerts(companyId, userId);
        }

        public List<DashboardAppointment> GetDashboardAppointment(int companyId)
        {
            return repository.GetAppointments(companyId);
        }

        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            return resp;
        }
    }
}
