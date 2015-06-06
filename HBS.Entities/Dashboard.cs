using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;
using System.Data;

namespace HBS.Entities
{
    public class DashboardAppointment : BaseEntity
    {
        public string DoctorName { get; set; }
        public int NoOfAppointments { get; set; }
        public DashboardAppointment()
        {

        }
        public DashboardAppointment(IDataReader dbReader)
            : this()
        {
            if (dbReader.HasColumn("DoctorName") && dbReader["DoctorName"] != DBNull.Value)
                DoctorName = (string)dbReader["DoctorName"];

            if (dbReader.HasColumn("TotalAppointment") && dbReader["TotalAppointment"] != DBNull.Value)
                NoOfAppointments = Convert.ToInt32(dbReader["TotalAppointment"]);
        }
    }
    public class Alert : BaseEntity
    {
        public int AssignedItems { get; set; }
        public int NoOfAppointments { get; set; }
        public int DueDateItems { get; set; }
    }
}
