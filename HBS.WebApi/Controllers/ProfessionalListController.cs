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
    public class ProfessionalListController : ApiController
    {
        public IProfessionalRepository professionalRepository;

        public ProfessionalListController(IProfessionalRepository repo)
        {
            professionalRepository = repo;
        }

        [HttpGet]

        public List<Professional> GetProfessionals(int companyId, string professionalName)
        {
            return professionalRepository.GetProfessionals(companyId, professionalName);
        }

    }
}
