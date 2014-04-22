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
    public class CustomerListByIdCustomerNameAndDob : ApiController
    {

         ICustomerRepository repository;

         public CustomerListByIdCustomerNameAndDob(ICustomerRepository repo)
        {
            repository = repo;
        }
      
        public IList<Customer> GetCustomerByIdNameDob(int customerId, string customerName,DateTime dob)
        {
            return repository.GetCustomers(customerId, customerName,dob);
        }
    }
}
