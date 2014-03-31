using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HBS.Data.Abstract;
using HBS.Entities;

namespace HBS.Data.Concrete
{
    public class ProfessionalRepository : BaseRepository, IProfessionalRepository
    {
        public bool AddProfessional(Professional professional)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfessional(Professional professional)
        {
            throw new NotImplementedException();
        }

        public Professional GetProfessional(int professionalId)
        {
            throw new NotImplementedException();
        }

        public List<Professional> GetProfessional(int companyId, string professionalName)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProfessional(int professionalId)
        {
            throw new NotImplementedException();
        }

        public bool AddProfessionalSchedule(ProfessionalSchedule professionalSchedule)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfessionalSchedule(ProfessionalSchedule professionalSchedule)
        {
            throw new NotImplementedException();
        }

        public ProfessionalSchedule GetProfessionalSchedule(int professionalSchedulreId)
        {
            throw new NotImplementedException();
        }

        public List<ProfessionalSchedule> GetProfessionalScheduleList(int professionalId)
        {
            throw new NotImplementedException();
        }

        public List<ProfessionalSchedule> GetProfessionalSchedule(DateTime scheduleDate)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProfessionalSchedule(int professionalSchduleId)
        {
            throw new NotImplementedException();
        }
    }
}
