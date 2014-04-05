using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Data.Abstract;
using HBS.Entities;
using System.Data.SqlClient;
using System.Data;

namespace HBS.Data.Concrete
{
   
  
    
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private const string Change = "Change";
        //private const string sp = "";
        //private const string sp = "";
        //private const string sp = "";
        //private const string sp = "";
        //private const string sp = "";
        //private const string sp = "";
        //private const string sp = "";
        //private const string sp = "";



        
        public bool AddCustomer(Customer customer)
        {
            
                
            
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customer.CustomerId; 

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = customer.CompanyId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = customer.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = customer.LastName;
                    cmd.Parameters.Add("@MiddleInitial", SqlDbType.VarChar).Value = customer.MiddleInitial;
                    cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = customer.Address1;
                    cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = customer.Address2;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = customer.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = customer.State;
                    cmd.Parameters.Add("@Zip", SqlDbType.VarChar).Value = customer.Zip;                   
                    cmd.Parameters.Add("@HomePhone", SqlDbType.VarChar).Value = customer.HomePhone;
                    cmd.Parameters.Add("@CellPhone", SqlDbType.VarChar).Value = customer.CellPhone;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = customer.CreatedBy;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return (bool)cmd.ExecuteScalar();

                }
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customer.CustomerId;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = customer.CompanyId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = customer.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = customer.LastName;
                    cmd.Parameters.Add("@MiddleInitial", SqlDbType.VarChar).Value = customer.MiddleInitial;
                    cmd.Parameters.Add("@Address1", SqlDbType.VarChar).Value = customer.Address1;
                    cmd.Parameters.Add("@Address2", SqlDbType.VarChar).Value = customer.Address2;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = customer.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = customer.State;
                    cmd.Parameters.Add("@Zip", SqlDbType.VarChar).Value = customer.Zip;
                    cmd.Parameters.Add("@HomePhone", SqlDbType.VarChar).Value = customer.HomePhone;
                    cmd.Parameters.Add("@CellPhone", SqlDbType.VarChar).Value = customer.CellPhone;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = customer.UpdatedBy;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return (bool)cmd.ExecuteScalar();
                }
            }
        }

        public List<Customer> GetCustomers(int companyId, string customerName)
        {
            var customer = new List<Customer>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;
                    if (!string.IsNullOrWhiteSpace(customerName))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                        cmd.Parameters["@Name"].Value = customerName;
                    }

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                customer.Add(new Customer(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return customer; 
        }

        public List<Customer> GetCustomers(int companyId, string customerName, DateTime Dob)
        {
            var customer = new List<Customer>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;
                    if (!string.IsNullOrWhiteSpace(customerName))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                        cmd.Parameters["@Name"].Value = customerName;
                    }

                    cmd.Parameters.Add("@Dob", SqlDbType.DateTime);
                    cmd.Parameters["@Dob"].Value = Dob;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                customer.Add(new Customer(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return customer; 
        }

        public Customer GetCustomer(int customerId)
        {
            Customer customer = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {

                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                    cmd.Parameters["@CustomerId"].Value = customerId;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                customer = new Customer(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }

            }
            return customer;

        }

        public bool RemoveCustomer(int customerId, int removedByUserId)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@professionalSchduleId", SqlDbType.Int).Value = customerId;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = false;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = removedByUserId;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddCustomerInsurance(CustomerInsurance customerInsurance)
        {
            
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customerInsurance.CustomerId;
                    cmd.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = customerInsurance.EffectiveDate;
                    cmd.Parameters.Add("@FirstName", SqlDbType.DateTime).Value = customerInsurance.EndDate;
                    cmd.Parameters.Add("@PcpName", SqlDbType.VarChar).Value = customerInsurance.PcpName;
                    cmd.Parameters.Add("@CustomerInsuranceNumber", SqlDbType.VarChar).Value = customerInsurance.CustomerInsuranceNumber;
                    cmd.Parameters.Add("@InsuranceType", SqlDbType.VarChar).Value = customerInsurance.InsuranceType;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = customerInsurance.CreatedBy;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return (bool)cmd.ExecuteScalar();

                }
            }
        }

        public bool UpdateCustomerInsurance(CustomerInsurance customerInsurance)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customerInsurance.CustomerId;
                    cmd.Parameters.Add("@EffectiveDate", SqlDbType.DateTime).Value = customerInsurance.EffectiveDate;
                    cmd.Parameters.Add("@FirstName", SqlDbType.DateTime).Value = customerInsurance.EndDate;
                    cmd.Parameters.Add("@PcpName", SqlDbType.VarChar).Value = customerInsurance.PcpName;
                    cmd.Parameters.Add("@CustomerInsuranceNumber", SqlDbType.VarChar).Value = customerInsurance.CustomerInsuranceNumber;
                    cmd.Parameters.Add("@InsuranceType", SqlDbType.VarChar).Value = customerInsurance.InsuranceType;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = customerInsurance.CreatedBy;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return (bool)cmd.ExecuteScalar();

                }
            }
        }

        public CustomerInsurance GetCustomerInsurance(int customerInsuranceId)
        {
            CustomerInsurance customerInsurance = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {

                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CustomerInsuranceId", SqlDbType.Int);
                    cmd.Parameters["@CustomerInsuranceId"].Value = customerInsuranceId;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                customerInsurance = new CustomerInsurance(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }

            }
            return customerInsurance;

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
