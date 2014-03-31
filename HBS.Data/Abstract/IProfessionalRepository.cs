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
        bool AddProfessional(Professional professional);
        bool UpdateProfessional(Professional professional);
        Professional GetProfessional(int professionalId);
        List<Professional> GetProfessional(int companyId, string professionalName);
        bool RemoveProfessional(int professionalId);


        bool AddProfessionalSchedule(ProfessionalSchedule professionalSchedule);
        bool UpdateProfessionalSchedule(ProfessionalSchedule professionalSchedule);
        ProfessionalSchedule GetProfessionalSchedule(int professionalSchedulreId);
        List<ProfessionalSchedule> GetProfessionalScheduleList(int professionalId);
        List<ProfessionalSchedule> GetProfessionalSchedule(DateTime scheduleDate);
        bool RemoveProfessionalSchedule(int professionalSchduleId);



    }
}
