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
    public class ProfessionalScheduleController : ApiController
    {


         public IProfessionalRepository professionalRepository;

         public ProfessionalScheduleController(IProfessionalRepository repo)
        {
            professionalRepository = repo;
        }
             
      
         
        public ProfessionalSchedule GetProfessionalScheduleById(int id)
        {
            return professionalRepository.GetProfessionalSchedule(id);
        }

        public bool PostProfessional([FromBody] ProfessionalSchedule  proSchedule)
        {
            return professionalRepository.AddProfessionalSchedule(proSchedule);

        }

        //TODO:Get confirmation. 
        //User the same method to soft delete dont need have another method to softdelete, this method does have IsActive param. 
        public bool PutProfessional([FromBody] ProfessionalSchedule proSchedule)
        {
            return professionalRepository.UpdateProfessionalSchedule(proSchedule);
        }
    }
}
