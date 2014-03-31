using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities;

namespace HBS.Data.Abstract
{
    public interface ICustomerRepository
    {
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        List<Customer> GetCustomers(int companyId, string customerName);
        List<Customer> GetCustomers(int companyId, string customerName, DateTime Dob);
        Customer GetCustomer(int customerId);
        bool RemoveCustomer(int customerId);


        bool AddCustomerInsurance(CustomerInsurance customerInsurance);
        bool UpdateCustomerInsurance(CustomerInsurance customerInsurance);
        CustomerInsurance GetCustomerInsurance(int customerInsuranceId);
        List<CustomerInsurance> GetCustomerInsurances(int companyId, string customerId);
        bool RemoveCustomerInsurance(int customerInsuranceId);

    }
}
