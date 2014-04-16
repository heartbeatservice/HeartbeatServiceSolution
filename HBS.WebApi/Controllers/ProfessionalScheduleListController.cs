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

namespace HBS.WebApi.Controllers
{
    public class ProfessionalScheduleListController : ApiController
    {


        public IProfessionalRepository professionalRepository;

        public ProfessionalScheduleListController(IProfessionalRepository repo)
        {
            professionalRepository = repo;
        }

        //[HttpGet]

        public List<ProfessionalSchedule> GetProfessionalsScheduleList(int id)
        {
            return professionalRepository.GetProfessionalScheduleListByScheduleId(id);
        }
   

}
}



    
