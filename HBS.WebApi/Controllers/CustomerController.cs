using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HBS.Data.Abstract;
using HBS.Data.Concrete;
using HBS.Entities;
using System.Web;
using HBS.WebApi.Models;
namespace HBS.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerRepository repository;
        public CustomerController(ICustomerRepository repo)
        {
            repository = repo;
        }

        public int PostCustomer([FromBody] Customer customer)
        {
            return repository.AddCustomer(customer);
        }
        public IList<Customer> GetCustomers(int companyId) //
        {
            return repository.GetCustomers(companyId, null);
        }
        public Customer GetCustomer(int customerId)
        {
            return repository.GetCustomer(customerId);
        }

        public IList<Customer> GetCustomers(int companyId, string customerName) //
        {
            return repository.GetCustomers(companyId, customerName);
        }

        public PagedList GetCustomers(int companyId, string customerName,int pageNumber, int pageSize) //
        {
            return GetCustomers(repository.GetCustomers(companyId,customerName), pageNumber, pageSize);
        }

        public PagedList GetCustomers(int companyId, int pageNumber, int pageSize) //
        {
            return GetCustomers(repository.GetCustomers(companyId,null), pageNumber, pageSize);
        }

        public IList<Customer> GetCustomers(int companyId, string customerName, DateTime dob)
        {
           
            return repository.GetCustomers(companyId, customerName, dob);
        }

        public PagedList GetCustomers(int companyId, string customerName, DateTime dob, int pageNumber, int pageSize)
        {

            return GetCustomers(repository.GetCustomers(companyId, customerName, dob),pageNumber,pageSize);
        }

        public IList<Customer> GetCustomers(int companyId, DateTime dob)
        {
            return repository.GetCustomers(companyId, null, dob);
        }

        public PagedList GetCustomers(int companyId, DateTime dob,int pageNumber, int pageSize)
        {
            return GetCustomers(repository.GetCustomers(companyId, null, dob),pageNumber,pageSize);
        }

        public PagedList GetCustomers(List<Customer> customer, int PageNumber, int PageSize)
        {
            var pagedRecord = new PagedList();
            pagedRecord.PageSize = PageSize;
            pagedRecord.CurrentPage = PageNumber;
            var customers = customer.AsQueryable();
            // Count
            int nTotalItems = customers.Count();
            customers = customers.Skip((PageNumber - 1) * PageSize)
                         .Take(PageSize);

            pagedRecord.Content = customers.ToList<Customer>();
            pagedRecord.TotalRecords = nTotalItems;
            return pagedRecord;
        }

        [HttpPut]
        public bool PutCustomerUpdate(string id,[FromBody] Customer customer)
        {
            return repository.UpdateCustomer(customer);
        }


        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            return resp;
        }
            // Todo: THE SP WAS MESSED UP AND THIS METHOD IS NOT WORKING AT THE MOMENT 4/18/2014
        public bool DeleteCustomer(int customerId, int userId)
        {
            return repository.RemoveCustomer(customerId, userId);
        }
    }
}
