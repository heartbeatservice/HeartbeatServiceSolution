using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;
using System.Data;

namespace HBS.Entities
{
    public class ProfessionalSchedule:BaseEntity
    {

        public int ProfessionalScheduleId { get; set; }
        public int ProfessionalId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimeIntervalMinutes { get; set; }

        public ProfessionalSchedule()
        { }

        public ProfessionalSchedule(IDataReader dbReader)
            : this()
        {
            if (dbReader.HasColumn("ProfessionalScheduleId") && dbReader["ProfessionalScheduleId"] != DBNull.Value)
                ProfessionalScheduleId = (int)dbReader["ProfessionalScheduleId"];
            
            if (dbReader.HasColumn("ProfessionalId") && dbReader["ProfessionalId"] != DBNull.Value)
                ProfessionalId = (int)dbReader["ProfessionalId"];
            
            if (dbReader.HasColumn("StartTime") && dbReader["StartTime"] != DBNull.Value)
                StartTime = (DateTime)dbReader["StartTime"];
            
            if (dbReader.HasColumn("EndTime") && dbReader["EndTime"] != DBNull.Value)
                EndTime = (DateTime)dbReader["EndTime"];
            
            if (dbReader.HasColumn("TimeIntervalMinutes") && dbReader["TimeIntervalMinutes"] != DBNull.Value)
                TimeIntervalMinutes = (int)dbReader["TimeIntervalMinutes"];        
            
            if (dbReader.HasColumn("CreatedBy") && dbReader["CreatedBy"] != DBNull.Value)
                CreatedBy = (int)dbReader["CreatedBy"];
            
            if (dbReader.HasColumn("UpdatedBy") && dbReader["UpdatedBy"] != DBNull.Value)
                UpdatedBy = (int)dbReader["UpdatedBy"];
            
            if (dbReader.HasColumn("DateCreated") && dbReader["DateCreated"] != DBNull.Value)
                DateCreated = (DateTime)dbReader["DateCreated"];
            
            if (dbReader.HasColumn("DateUpdated") && dbReader["DateUpdated"] != DBNull.Value)
                DateUpdated = (DateTime)dbReader["DateUpdated"];
        }


    }
}
