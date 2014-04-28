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
    public class CustomerController : ApiController
    {
        private ICustomerRepository repository;
        public CustomerController(ICustomerRepository repo)
        {
            repository = repo;
        }

        public bool PostCustomer([FromBody] Customer customer)
        {
            return repository.AddCustomer(customer);
        }

        public Customer GetCustomer(int customerId)
        {
            return repository.GetCustomer(customerId);
        }

        

        public bool PutCustomerUpdate([FromBody] Customer customer)
        {
            return repository.UpdateCustomer(customer);
        }

            // Todo: THE SP WAS MESSED UP AND THIS METHOD IS NOT WORKING AT THE MOMENT 4/18/2014
        public bool DeleteCustomer(int customerId, int userId)
        {
            return repository.RemoveCustomer(customerId, userId);
        }
    }
}