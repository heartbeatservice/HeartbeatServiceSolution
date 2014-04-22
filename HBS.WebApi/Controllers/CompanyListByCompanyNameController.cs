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
    public class CompanyListByCompanyNameController : ApiController
    {

         ICommonRepository repository;
         public CompanyListByCompanyNameController(ICommonRepository repo)
        {
            repository = repo;
        }

        public IList<Company> GetAllCompanies(string companyName)
        {
            return repository.GetCompanies(companyName);
        }
    }
}
