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
    public class CustomerListByIdAndCustomerNameController : ApiController
    {
        ICustomerRepository repository;

        public CustomerListByIdAndCustomerNameController(ICustomerRepository repo)
        {
            repository = repo;
        }


        //I dont know why returning list when we have customerid
        public IList<Customer> GetCustomerByIdAndName(int customerId, string customerName)
        {
            return repository.GetCustomers(customerId, customerName);
        }
    }
}
