﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;
using System.Data;

namespace HBS.Entities
{
    public class CustomerInsurance : BaseEntity
    {
        public int InsuranceId { get; set; }
        public int CustomerInsuranceID { get; set; }
        public int CustomerId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PcpName { get; set; }
        public string CustomerInsuranceNumber { get; set; }
        public string InsuranceType { get; set; }
        public string InsuranceName { get; set; }
        public Customer customer;

        public bool IsActive { get; set; }

        public CustomerInsurance()
        {
            customer = new Customer();
        }

        public CustomerInsurance(IDataReader dbReader)
            : this()
        {
            if (dbReader.HasColumn("InsuranceId") && dbReader["InsuranceId"] != DBNull.Value)
                InsuranceId = (int)dbReader["InsuranceId"];

            if (dbReader.HasColumn("CustomerInsuranceID") && dbReader["CustomerInsuranceID"] != DBNull.Value)
                CustomerInsuranceID = (int)dbReader["CustomerInsuranceID"];

            if (dbReader.HasColumn("CustomerId") && dbReader["CustomerId"] != DBNull.Value)
                CustomerId = (int)dbReader["CustomerId"];

            if (dbReader.HasColumn("EffectiveDate") && dbReader["EffectiveDate"] != DBNull.Value)
                EffectiveDate = ((DateTime)dbReader["EffectiveDate"]);

            if (dbReader.HasColumn("EndDate") && dbReader["EndDate"] != DBNull.Value)
                EndDate = ((DateTime)dbReader["EndDate"]);

            if (dbReader.HasColumn("PCPName") && dbReader["PCPName"] != DBNull.Value)
                PcpName = (string)dbReader["PCPName"];

            if (dbReader.HasColumn("IsActive") && dbReader["IsActive"] != DBNull.Value)
                IsActive = (bool)dbReader["IsActive"];

            if (dbReader.HasColumn("CustomerInsuranceNumber") && dbReader["CustomerInsuranceNumber"] != DBNull.Value)
                CustomerInsuranceNumber = (string)dbReader["CustomerInsuranceNumber"];

            if (dbReader.HasColumn("InsuranceType") && dbReader["InsuranceType"] != DBNull.Value)
                InsuranceType = (string)dbReader["InsuranceType"];


            if (dbReader.HasColumn("InsuranceName") && dbReader["InsuranceName"] != DBNull.Value)
                InsuranceName = (string)dbReader["InsuranceName"];

       //customer Info
            if (dbReader.HasColumn("FirstName") && dbReader["FirstName"] != DBNull.Value)
                customer.FirstName = (string)dbReader["FirstName"];
            if (dbReader.HasColumn("LastName") && dbReader["LastName"] != DBNull.Value)
                customer.LastName = (string)dbReader["LastName"];
            if (dbReader.HasColumn("DateOfBirth") && dbReader["DateOfBirth"] != DBNull.Value)
                customer.DateOfBirth = Convert.ToDateTime(dbReader["DateOfBirth"]).ToShortDateString();

        }

    }
}
