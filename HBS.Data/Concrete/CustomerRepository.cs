using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Data.Abstract;
using HBS.Entities;

namespace HBS.Data.Concrete
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public bool AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers(int companyId, string customerName)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers(int companyId, string customerName, DateTime Dob)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool AddCustomerInsurance(CustomerInsurance customerInsurance)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomerInsurance(CustomerInsurance customerInsurance)
        {
            throw new NotImplementedException();
        }

        public CustomerInsurance GetCustomerInsurance(int customerInsuranceId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerInsurance> GetCustomerInsurances(int companyId, string customerId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomerInsurance(int customerInsuranceId)
        {
            throw new NotImplementedException();
        }
    }
}
