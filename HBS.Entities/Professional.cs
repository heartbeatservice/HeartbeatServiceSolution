using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;

namespace HBS.Entities
{
    class Professional: BaseEntity
    {

        public int ProfessionalId { get; set; }
        public int ProfessionalTypeId{ get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string ProfessionalIdentificationNumber { get; set; }

        public Professional()
        { }

        public Professional(IDataReader dbReader)
            : this()
        {

            if (dbReader.HasColumn("ProfessionalId") && dbReader["ProfessionalId"] != DBNull.Value)
                ProfessionalId = (int)dbReader["ProfessionalId"];
            if (dbReader.HasColumn("ProfessionalTypeId") && dbReader["ProfessionalTypeId"] != DBNull.Value)
                ProfessionalTypeId = (int)dbReader["ProfessionalTypeId"];
            if (dbReader.HasColumn("CompanyId") && dbReader["CompanyId"] != DBNull.Value)
                CompanyId = (int)dbReader["CompanyId"];
            if (dbReader.HasColumn("FirstName") && dbReader["FirstName"] != DBNull.Value)
                FirstName = (string)dbReader["FirstName"];
            if (dbReader.HasColumn("LastName") && dbReader["LastName"] != DBNull.Value)
                LastName = (string)dbReader["LastName"];
            if (dbReader.HasColumn("Phone") && dbReader["Phone"] != DBNull.Value)
                Phone = (string)dbReader["Phone"];
            if (dbReader.HasColumn("ProfessionalIdentificationNumber") && dbReader["ProfessionalIdentificationNumber"] != DBNull.Value)
                ProfessionalIdentificationNumber = (string)dbReader["ProfessionalIdentificationNumber"];
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
