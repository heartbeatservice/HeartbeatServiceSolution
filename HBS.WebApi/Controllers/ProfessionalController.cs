﻿using System;
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
    public class ProfessionalController : ApiController
    {
        public IProfessionalRepository professionalRepository;

       public  ProfessionalController(IProfessionalRepository repo)
        {
            professionalRepository = repo;
        }

        
      
         
        public Professional GetProfessionalById(int id)
        {
            return professionalRepository.GetProfessional(id);
        }

        public int PostProfessional([FromBody] Professional pro)
        {
           return professionalRepository.AddProfessional(pro);

        }

        public bool PutProfessional([FromBody] Professional pro)
        {
            return professionalRepository.UpdateProfessional(pro);
        }

              




    }
}