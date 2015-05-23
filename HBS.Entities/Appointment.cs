using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;
using System.Data;

namespace HBS.Entities
{
    public class Appointment : BaseEntity
    {
        public int AppointmentId { get; set; }
        public int ProfessionalId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CustomerDOB { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmailAddress { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentStartTime { get; set; }
        public int StatusId { get; set; }
        public string Comments { get; set; }


        public Appointment()
        {

        }

        public Appointment(IDataReader dbReader)
            : this()
        {
            if (dbReader.HasColumn("AppointmentId") && dbReader["AppointmentId"] != DBNull.Value)
                AppointmentId = (int)dbReader["AppointmentId"];

            if (dbReader.HasColumn("ProfessionalId") && dbReader["ProfessionalId"] != DBNull.Value)
                ProfessionalId = (int)dbReader["ProfessionalId"];

            if (dbReader.HasColumn("CustomerId") && dbReader["CustomerId"] != DBNull.Value)
                CustomerId = (int)dbReader["CustomerId"];

            if (dbReader.HasColumn("CustomerName") && dbReader["CustomerName"] != DBNull.Value)
                CustomerName = (string)dbReader["CustomerName"];

            if (dbReader.HasColumn("AppointmentDate") && dbReader["AppointmentDate"] != DBNull.Value)
                AppointmentDate = (DateTime)dbReader["AppointmentDate"];

            if (dbReader.HasColumn("AppointmentStartTime") && dbReader["AppointmentStartTime"] != DBNull.Value)
                AppointmentStartTime = (DateTime)dbReader["AppointmentStartTime"];

            if (dbReader.HasColumn("StatusId") && dbReader["StatusId"] != DBNull.Value)
                StatusId = (int)dbReader["StatusId"];

            if (dbReader.HasColumn("Comments") && dbReader["Comments"] != DBNull.Value)
                Comments = (string)dbReader["Comments"];

            if (dbReader.HasColumn("CreatedBy") && dbReader["CreatedBy"] != DBNull.Value)
                base.CreatedBy = (int)dbReader["CreatedBy"];

            if (dbReader.HasColumn("UpdatedBy") && dbReader["UpdatedBy"] != DBNull.Value)
                base.UpdatedBy = (int)dbReader["UpdatedBy"];

            if (dbReader.HasColumn("DateCreated") && dbReader["DateCreated"] != DBNull.Value)
                base.DateCreated = (DateTime)dbReader["DateCreated"];

            if (dbReader.HasColumn("DateUpdated") && dbReader["DateUpdated"] != DBNull.Value)
                base.DateUpdated = (DateTime)dbReader["DateUpdated"];

            if (dbReader.HasColumn("DateOfBirth") && dbReader["DateOfBirth"] != DBNull.Value)
                this.CustomerDOB = (DateTime)dbReader["DateOfBirth"];

            if (dbReader.HasColumn("Address1") && dbReader["Address1"] != DBNull.Value)
                this.CustomerAddress = (string)dbReader["Address1"];

            if (dbReader.HasColumn("Address2") && dbReader["Address2"] != DBNull.Value)
                this.CustomerAddress += " " + (string)dbReader["Address2"];

            if (dbReader.HasColumn("City") && dbReader["City"] != DBNull.Value)
                this.CustomerAddress += " " + (string)dbReader["City"];

            if (dbReader.HasColumn("State") && dbReader["State"] != DBNull.Value)
                this.CustomerAddress += " " + (string)dbReader["State"];

            if (dbReader.HasColumn("Zip") && dbReader["Zip"] != DBNull.Value)
                this.CustomerAddress += " " + (string)dbReader["Zip"];

            if (dbReader.HasColumn("Email") && dbReader["Email"] != DBNull.Value)
                this.CustomerEmailAddress = (string)dbReader["Email"];

            if (dbReader.HasColumn("HomePhone") && dbReader["HomePhone"] != DBNull.Value)
                this.CustomerPhone = (string)dbReader["HomePhone"];
        }
    }
}


