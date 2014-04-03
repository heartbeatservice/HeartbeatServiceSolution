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
        public int CustomerId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PcpName { get; set; }
        public string CustomerInsuranceNumber { get; set; }
        public string InsuranceType { get; set; }
        public List<CustomerInsurance> CustomerInsurances { get; set; }


        public CustomerInsurance()
        {
            CustomerInsurances = new List<CustomerInsurance>();
        }

        public CustomerInsurance(IDataReader dbReader)
            : this()
        {
            if (dbReader.HasColumn("InsuranceId") && dbReader["InsuranceId"] != DBNull.Value)
                InsuranceId = (int)dbReader["InsuranceId"];

            if (dbReader.HasColumn("CustomerId") && dbReader["CustomerId"] != DBNull.Value)
                CustomerId = (int)dbReader["CustomerId"];

            if (dbReader.HasColumn("EffectiveDate") && dbReader["EffectiveDate"] != DBNull.Value)
                EffectiveDate = (DateTime)dbReader["EffectiveDate"];

            if (dbReader.HasColumn("EndDate") && dbReader["EndDate"] != DBNull.Value)
                EndDate = (DateTime)dbReader["EndDate"];

            if (dbReader.HasColumn("PcpName") && dbReader["PcpName"] != DBNull.Value)
                PcpName = (string)dbReader["PcpName"];

            if (dbReader.HasColumn("CustomerInsuranceNumber") && dbReader["CustomerInsuranceNumber"] != DBNull.Value)
                CustomerInsuranceNumber = (string)dbReader["CustomerInsuranceNumber"];

            if (dbReader.HasColumn("Insurances") && dbReader["Insurances"] != DBNull.Value)
                InsuranceType = (string)dbReader["Insurances"];

            if (dbReader.HasColumn("CreatedBy") && dbReader["CreatedBy"] != DBNull.Value)
                base.CreatedBy = (int)dbReader["CreatedBy"];

            if (dbReader.HasColumn("UpdatedBy") && dbReader["UpdatedBy"] != DBNull.Value)
                base.UpdatedBy = (int)dbReader["UpdatedBy"];

            if (dbReader.HasColumn("DateCreated") && dbReader["DateCreated"] != DBNull.Value)
                base.DateCreated = (DateTime)dbReader["DateCreated"];

            if (dbReader.HasColumn("DateUpdated") && dbReader["DateUpdated"] != DBNull.Value)
                base.DateUpdated = (DateTime)dbReader["DateUpdated"];

        }

    }
}
