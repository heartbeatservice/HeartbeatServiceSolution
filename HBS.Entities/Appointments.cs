using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;
using System.Data;

namespace HBS.Entities
{
    public class Appointments:BaseEntity
    {


       
            public int AppointmentId { get; set; }
            public int ProfessionalId { get; set; }
            public int CustomerId { get; set; }
            public DateTime AppointmentDate {get; set;}
            public string AppointmentStartTime {get;set;}
            public int StatusId {get; set;}
            public string Comments{get;set;}
            
           
           public Appointments()
            {

            }



           

            //public Appointments(IDataReader dbReader)
            //    : this()
            //{
            //    if (dbReader.HasColumn("AppointmentId") && dbReader["AppointmentId"] != DBNull.Value) AppointmentId = (int)dbReader["AppointmentId"];
            //    if (dbReader.HasColumn("ProfessionalId") && dbReader["ProfessionalId"] != DBNull.Value) ProfessionalId = (string)dbReader["ProfessionalId"];
            //    if (dbReader.HasColumn("IsEmergent") && dbReader["IsEmergent"] != DBNull.Value) IsEmergent = (bool)dbReader["IsEmergent"];
            //}
        }
}
    

