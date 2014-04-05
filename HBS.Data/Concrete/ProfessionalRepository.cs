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

        private const string GetProfessionalByIdSp = "GetProfessionalById";
        private const string GetProfessionalsSp = "GetProfessionals";
        private const string AddProfessionalSp = "AddProfessional";
        private const string UpdateProfessionalSp = "UpdateProfessional";
         private const string Change = "Amir";
         //private const string Change = "Amir";
         //private const string Change = "Amir";
         //private const string Change = "Amir";

        public int AddProfessional(Professional professional)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(AddProfessionalSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProfessionalTypeId", SqlDbType.Int).Value = professional.ProfessionalTypeId;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = professional.CompanyId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = professional.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = professional.LastName;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = professional.Phone;
                    cmd.Parameters.Add("@ProfessionalIdentificationNumber", SqlDbType.VarChar).Value = professional.ProfessionalIdentificationNumber;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = professional.CreatedBy;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return (int)cmd.ExecuteScalar();

                }
            }
        }






        public bool UpdateProfessional(Professional professional)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateProfessionalSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int).Value = professional.ProfessionalId;
                    cmd.Parameters.Add("@ProfessionalTypeId", SqlDbType.Int).Value = professional.ProfessionalTypeId;
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = professional.CompanyId;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = professional.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = professional.LastName;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = professional.Phone;
                    cmd.Parameters.Add("@ProfessionalIdentificationNumber", SqlDbType.VarChar).Value = professional.ProfessionalIdentificationNumber;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = professional.IsActive;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = professional.UpdatedBy;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Professional GetProfessional(int professionalId)
        {
            Professional professional = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {

                conn.Open();

                using (var cmd = new SqlCommand(GetProfessionalByIdSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;                    
                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int);
                    cmd.Parameters["@ProfessionalId"].Value = professionalId;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)                            {
                                myReader.Read();
                                professional = new Professional(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }

            }
            return professional;

        }

        public List<Professional> GetProfessionals(int companyId, string professionalName)
        {

            var professionals = new List<Professional>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GetProfessionalsSp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int);
                    cmd.Parameters["@CompanyId"].Value = companyId;

                    if (!string.IsNullOrWhiteSpace(professionalName))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                        cmd.Parameters["@Name"].Value = professionalName;
                    }

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                professionals.Add(new Professional(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return professionals;
        }



        public bool RemoveProfessional(int professionalId, int removedBy)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(UpdateProfessionalSp, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int).Value = professionalId;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = false;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = removedBy;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AddProfessionalSchedule(ProfessionalSchedule professionalSchedule)
        {
            
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 
                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int).Value = professionalSchedule.ProfessionalId;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = professionalSchedule.StartTime;
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = professionalSchedule.EndTime;
                    cmd.Parameters.Add("@TimeIntervalMinutes", SqlDbType.Int).Value = professionalSchedule.TimeIntervalMinutes;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = professionalSchedule.CreatedBy;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return (bool)cmd.ExecuteScalar();

                }
            }
        }

        public bool UpdateProfessionalSchedule(ProfessionalSchedule professionalSchedule)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProfessionalScheduleId", SqlDbType.Int).Value = professionalSchedule.ProfessionalScheduleId;
                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int).Value = professionalSchedule.ProfessionalId;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = professionalSchedule.StartTime;
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = professionalSchedule.EndTime;
                    cmd.Parameters.Add("@TimeIntervalMinutes", SqlDbType.Int).Value = professionalSchedule.TimeIntervalMinutes;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar).Value = professionalSchedule.UpdatedBy;
                    cmd.Parameters.Add("@DateUpdated", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;

                }
            }
        }

        public ProfessionalSchedule GetProfessionalSchedule(int professionalSchedulreId)
        {
            ProfessionalSchedule professionalSchedule = null;
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {

                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ProfessionalSchedulreId", SqlDbType.Int);
                    cmd.Parameters["@ProfessionalSchedulreId"].Value = professionalSchedulreId;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            if (myReader.HasRows)
                            {
                                myReader.Read();
                                professionalSchedule = new ProfessionalSchedule(myReader);
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }

            }
            return professionalSchedule;

        }

        public List<ProfessionalSchedule> GetProfessionalScheduleList(int professionalId)
        {
            var professionalSchedule = new List<ProfessionalSchedule>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ProfessionalId", SqlDbType.Int);
                    cmd.Parameters["@ProfessionalId"].Value = professionalId;                   

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                professionalSchedule.Add(new ProfessionalSchedule(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return professionalSchedule;
        }

        public List<ProfessionalSchedule> GetProfessionalSchedule(DateTime scheduleDate)
        {
            var professionalSchedule = new List<ProfessionalSchedule>();
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ScheduleDate", SqlDbType.DateTime);
                    cmd.Parameters["@ScheduleDate"].Value = scheduleDate;

                    using (var myReader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                professionalSchedule.Add(new ProfessionalSchedule(myReader));
                            }
                        }
                        catch (Exception ex)
                        {
                            // TODO Logg Error here
                        }
                    }
                }
            }
            return professionalSchedule;
        }

        public bool RemoveProfessionalSchedule(int professionalSchduleId, int removedByUserId)
        {
            using (var conn = new SqlConnection(PrescienceRxConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Change, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProfessionalSchduleId", SqlDbType.Int).Value = professionalSchduleId;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = false;
                    cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = removedByUserId;
                    cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.UtcNow;

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
