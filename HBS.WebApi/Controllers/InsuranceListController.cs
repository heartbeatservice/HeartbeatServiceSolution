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
    public class InsuranceListController : ApiController
    {

          ICommonRepository repository;
          public InsuranceListController(ICommonRepository repo)
        {
            repository = repo;
        }

        public IList<Insurance> GetInsurancesList(int companyId,string insuranceName)
        {
            return repository.GetInsurances(companyId, insuranceName);
        }
    }
}
