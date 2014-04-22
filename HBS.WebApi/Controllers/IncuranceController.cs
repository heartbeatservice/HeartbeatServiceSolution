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
    public class IncuranceController : ApiController
    {

        ICommonRepository repository;

        public IncuranceController(ICommonRepository repo)
        {
            repository= repo;
        }

        public bool PostAddInsurnace([FromBody] Insurance insurance)
        {
            return repository.AddInsurance(insurance);
        }

        public Insurance GetInsurance(int insuranceId)
        {
            return repository.GetInsurance(insuranceId);

        }

        public bool PutUpdateInsurance([FromBody] Insurance insurance)
        {
            return repository.UpdateInsurance(insurance);
        }

        public bool DeleteInactiveInsurance(int insuranceId, int updatedBy)
        {
            return repository.RemoveInsurance(insuranceId, updatedBy);
        }
    }
}
