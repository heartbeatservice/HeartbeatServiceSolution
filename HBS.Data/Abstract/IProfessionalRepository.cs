using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities;

namespace HBS.Data.Abstract
{
    public interface IProfessionalRepository
    {
        int AddProfessional(Professional professional);
        bool UpdateProfessional(Professional professional);
        Professional GetProfessional(int professionalId);
<<<<<<< HEAD
<<<<<<< HEAD
        List<Professional> GetProfessionals(int companyId, string professionalName);
        bool RemoveProfessional(int professionalId);
=======
        List<Professional> GetProfessional(int companyId, string professionalName);
        bool RemoveProfessional(int professionalId,int removedBy);
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d
=======
        List<Professional> GetProfessional(int companyId, string professionalName);
        bool RemoveProfessional(int professionalId,int removedBy);
>>>>>>> a0b577e90d686fa330813b20a2c36b2457fcfb5d


        bool AddProfessionalSchedule(ProfessionalSchedule professionalSchedule);
        bool UpdateProfessionalSchedule(ProfessionalSchedule professionalSchedule);
        ProfessionalSchedule GetProfessionalSchedule(int professionalSchedulreId);
        List<ProfessionalSchedule> GetProfessionalScheduleList(int professionalId);
        List<ProfessionalSchedule> GetProfessionalSchedule(DateTime scheduleDate);
        bool RemoveProfessionalSchedule(int professionalSchduleId);



    }
}
